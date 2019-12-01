using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsAppArchiveReader
{
    static class Style
    {
        public static RichTextBox IndentBetweenMessages(RichTextBox rtb)
        {
            rtb.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 3F);
            rtb.SelectedText = "\n\n";

            return rtb;
        }

        public static RichTextBox Date(RichTextBox rtb, string strDate)
        {
            rtb.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            rtb.SelectionAlignment = HorizontalAlignment.Center;
            rtb.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#d9eafa");
            rtb.SelectionColor = Color.Black;
            rtb.SelectedText = strDate;

            return rtb;
        }

        public static RichTextBox MyMessage(RichTextBox rtb, string strMessage)
        {
            rtb.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            rtb.SelectionAlignment = HorizontalAlignment.Right;
            rtb.SelectionBackColor = System.Drawing.ColorTranslator.FromHtml("#e2ffc8");
            rtb.SelectionColor = Color.Black;
            rtb.SelectedText = MessageLines.ExtractMessage(strMessage);

            rtb.SelectionColor = System.Drawing.ColorTranslator.FromHtml("#889a77");
            rtb.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            rtb.SelectedText = MessageLines.ExtractShortTime(strMessage);

            return rtb;
        }
       
        public static RichTextBox ChatMembersMessage(RichTextBox rtb, string strMessage)
        {
            rtb.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            rtb.SelectionAlignment = HorizontalAlignment.Left;
            rtb.SelectionBackColor = Color.White;
            rtb.SelectionColor = Color.Black;
            rtb.SelectedText = MessageLines.ExtractMessage(strMessage);

            rtb.SelectionBackColor = Color.White;
            rtb.SelectionColor = System.Drawing.ColorTranslator.FromHtml("#9a9a9a");
            rtb.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            rtb.SelectedText = "\n" + MessageLines.ExtractShortTime(strMessage);

            return rtb;
        }
        
        public static Panel DragDropPanel(Panel panelDragDrop, PaintEventArgs evnt)
        {
            Pen pen = new Pen(Color.SlateGray, 2);
            pen.DashPattern = new float[] { 2, 2 };
            evnt.Graphics.DrawRectangle(pen, 1, 1, panelDragDrop.Width - 2, panelDragDrop.Height - 2);
            return panelDragDrop;
        }
    }
}