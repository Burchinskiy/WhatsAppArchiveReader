using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WhatsAppArchiveReader
{
    static class WhatsAppArchive
    {
        enum MessageType { Anroid, Iphone, Unknow };

        public static readonly char FileSeparator = Convert.ToChar(System.Net.WebUtility.HtmlDecode("&#8206;")); // '‎'
        public static readonly char NameStartSeparator = Convert.ToChar(System.Net.WebUtility.HtmlDecode("&#8234;")); // '‪'
        public static readonly char NameEndSeparator = Convert.ToChar(System.Net.WebUtility.HtmlDecode("&#8236;")); // '‬'

        public static readonly string UnzipDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static readonly string FilePrefix = "file://";

        static string DeleteSpecialCharacters(string strWithSpecialCharacters)
        {
            if (strWithSpecialCharacters.Contains(NameStartSeparator))
            {
                strWithSpecialCharacters = String.Join(String.Empty, strWithSpecialCharacters.Split(NameStartSeparator));
            }
            if (strWithSpecialCharacters.Contains(NameEndSeparator))
            {
                strWithSpecialCharacters = String.Join(String.Empty, strWithSpecialCharacters.Split(NameEndSeparator));
            }
            if (strWithSpecialCharacters.Substring(0,1).Equals(FileSeparator.ToString()))
            {
                strWithSpecialCharacters = strWithSpecialCharacters.Substring(1, strWithSpecialCharacters.Length - 1);
            }

            return strWithSpecialCharacters;
        }
        static void ClearTempDir()
        {
            System.IO.DirectoryInfo directoryInfo = new DirectoryInfo(UnzipDirectory);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                if (!(file.Name.Contains("WhatsAppArchiveReader")))
                {
                    file.Delete();
                }
            }
        }

        static MessageType CheckFileLink(string strForCheck)
        {
            string[] arrTypes =
            {
                @"[(][ф][а][й][л]\s[д][о][б][а][в][л][е][н][)]",
                @"[<][п][р][и][к][р][е][п][л][е][н][о][:]"
            };

            for (int count = 0; count < arrTypes.Length; count++)
            {
                if (Regex.IsMatch(strForCheck, arrTypes[count]))
                {
                    return (MessageType)count;
                }
            }
            return MessageType.Unknow;
        }

        static string FileLinker(string strWithFileLink, MessageType typeOfMessage)
        {
            switch (typeOfMessage)
            {
                case MessageType.Anroid:
                    if (strWithFileLink != null)
                    {
                        strWithFileLink = strWithFileLink.Replace("(файл добавлен)", "");

                        string[] mStrings = strWithFileLink.Split(FileSeparator);

                        strWithFileLink = mStrings[0] + mStrings[1].Insert(0, FilePrefix);
                    }
                    return strWithFileLink;

                case MessageType.Iphone:
                    if (strWithFileLink != null)
                    {
                        string[] mStrings = Regex.Split(strWithFileLink, @"[<][п][р][и][к][р][е][п][л][е][н][о][:]\s");

                        mStrings[1] = mStrings[1].Insert(0, FilePrefix);

                        strWithFileLink = string.Join("", mStrings).Replace(">", "");
                    }
                    return strWithFileLink; 

                default:
                    return strWithFileLink;
            }
        }

        static MessageType CheckDateTimeFormat(string strForCheck)
        {
            string[] arrTypes =
            {
                @"^\d\d[.]\d\d[.]\d\d[,]\s\d\d?[:]\d\d\s[-]",
                @"[[]\d\d[.]\d\d[.]\d\d\d\d[,]\s\d\d[:]\d\d[:]\d\d[]]"
            };
            
            for (int count = 0; count < arrTypes.Length; count++)
            {
                if (Regex.IsMatch(strForCheck, arrTypes[count]))
                {
                    return (MessageType)count;
                }
            }
            return MessageType.Unknow;
        }
                 
        static string DateTimeTranslate(string strWithDateTime, MessageType typeOfMessage)
        {
            DateTime dateTime;

            switch (typeOfMessage)
            {
                case MessageType.Anroid:
                    if (strWithDateTime != null)
                    {
                        if (Regex.IsMatch(strWithDateTime, @"^\d\d[.]\d\d[.]\d\d[,]\s\d[:]\d\d\s[-]"))
                        {
                            strWithDateTime = strWithDateTime.Insert(10, "0");
                        }

                        dateTime = DateTime.ParseExact
                        (
                            strWithDateTime.Remove(15, strWithDateTime.Length - 15),
                            "dd.MM.yy, HH:mm",
                            CultureInfo.InvariantCulture
                        );
                        strWithDateTime = dateTime + " - " + strWithDateTime.Remove(0, 18);
                    }
                    return strWithDateTime;

                case MessageType.Iphone:
                    if (strWithDateTime != null)
                    {
                        dateTime = DateTime.ParseExact
                        (
                            strWithDateTime.Remove(22, strWithDateTime.Length - 22),
                            "[dd.MM.yyyy, HH:mm:ss]",
                            CultureInfo.InvariantCulture
                        );
                        strWithDateTime = dateTime + " - " + strWithDateTime.Remove(0, 23);
                    }
                    return strWithDateTime;

                default:
                    return "";
            }
        }
               
        static void DeterminePerson(string strWithPerson)
        {
            List<string> strWholeFile = strWithPerson.Split('\n').ToList();
            List<string> strToPersonList = new List<string>();
            
            foreach (string str in strWholeFile)
            {
                if (!(String.IsNullOrEmpty(str)) && MessageLines.IsContainsPerson(str))
                {
                    strToPersonList.Add(MessageLines.ExtractName(str));
                }
            }
            PersonList.Persons = strToPersonList.Distinct().ToList();
        }

        public static void ClearTemp()
        {
            PersonList.ClearPersonList();
            ClearTempDir();
        }

        public static string UnzipAndReadFile(string pathToZip)
        {
            ClearTemp();

            ZipFile.ExtractToDirectory(pathToZip, UnzipDirectory);

            string strWholeFile = "";

            string pathToTxtFile = Directory.GetFiles(UnzipDirectory, "*.txt")[0];

            using (StreamReader reader = File.OpenText(pathToTxtFile))
            {
                string strOneMessage = "";

                do
                {
                    strOneMessage = reader.ReadLine();

                    if (!String.IsNullOrEmpty(strOneMessage))
                    {
                        strOneMessage = DeleteSpecialCharacters(strOneMessage);
                        strOneMessage = DateTimeTranslate(strOneMessage, CheckDateTimeFormat(strOneMessage));
                        strOneMessage = FileLinker(strOneMessage, CheckFileLink(strOneMessage));
                        strWholeFile += strOneMessage + "\n";
                    }
                }
                while (strOneMessage != null);
            }
            DeterminePerson(strWholeFile);
            return strWholeFile;
        }
    }
}