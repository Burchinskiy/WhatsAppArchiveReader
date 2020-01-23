using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsAppArchiveReader
{
    public static class DragAndDrop
    {
        public static void Enter(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        public static string Drop(DragEventArgs e)
        {
            List<string> paths = new List<string>();
            foreach (string obj in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                if (Directory.Exists(obj))
                {
                    paths.AddRange(Directory.GetFiles(obj, "*.*", SearchOption.AllDirectories));
                }
                else
                {
                    paths.Add(obj);
                }
            }

            // Поддержка добавления сразу нескольких архивов (будет добавлена в дальнейшем)
            #if false
            string.Join("\r\n", paths);
            #endif

            return paths[0];
        }

        public static string Click(string s)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = s;
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (file.ShowDialog() == DialogResult.OK)
            {
                return file.FileName;
            }
            return "";
        }
    }
}
