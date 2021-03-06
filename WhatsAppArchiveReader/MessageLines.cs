﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppArchiveReader
{
    class MessageLines
    {
        static int dateTimeLenght = DateTime.Now.ToString().Length;

        private static string RemoveDateTime(string strToCrop)
        {
            if (strToCrop.Length > dateTimeLenght)
            {
                return strToCrop.Remove(0, dateTimeLenght);
            }
            return strToCrop;
        }

        public static string ExtractName(string strWithName)
        {
            return RemoveDateTime(strWithName).Split('-')[1].Split(':')[0].Trim();
        }

        public static string ExtractShortTime(string strWithTime)
        {
            return Convert.ToDateTime(strWithTime.Remove(dateTimeLenght,
                strWithTime.Length - dateTimeLenght)).ToShortTimeString() + ' ';
        }

        public static string ExtractDate(string strWithDate)
        {
            var dateTime = Convert.ToDateTime(strWithDate.Substring(0, dateTimeLenght));
            var format = CultureInfo.CurrentCulture.DateTimeFormat;
            var dayOfWeek = format.GetDayName(dateTime.DayOfWeek);
            var month = format.GetAbbreviatedMonthName(dateTime.Month);

            return $" {dayOfWeek}, {dateTime.Day} {month} {dateTime.Year} \n";
        }
        
        public static string ExtractMessage(string strWithMessage)
        {
            string strWithoutDateTime = RemoveDateTime(strWithMessage);

            if (strWithoutDateTime.Contains(':'))
            {
                return strWithoutDateTime.Substring(strWithoutDateTime.IndexOf(':') + 1).TrimStart() + ' ';
            }
            else
            {
                return strWithoutDateTime.Split('-')[1].Trim();
            }
        }

        public static bool IsContainsPerson(string strForCheck)
        {
            return (RemoveDateTime(strForCheck).Contains(':'));
        }
    }
}
