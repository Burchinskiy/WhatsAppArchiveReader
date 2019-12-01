using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WhatsAppArchiveReader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnMainFormClosing(object sender, FormClosingEventArgs e)
        {
            WhatsAppArchive.ClearTemp();
        }

        private void OnDragDropPanelPainted(object sender, PaintEventArgs e)
        {
            Style.DragDropPanel(DragDropPanel, e);
        }

        private void OnChatRichTextBoxLinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText.Insert(WhatsAppArchive.FilePrefix.Length, WhatsAppArchive.UnzipDirectory));
        }

        private void OnDragDropPanelClicked(object sender, EventArgs e)
        {
            UnzipAndConvertFile(DragAndDrop.Click("Укажите необходимый файл"));
        }

        private void OnDragDropPanelEntered(object sender, DragEventArgs e)
        {
            DragAndDrop.Enter(e);
            DragDropLabel.Text = "Drop File Here!";
        }

        private void OnDragDropPanelLeaved(object sender, EventArgs e)
        {
            DragDropLabel.Text = "Drag and Drop";
        }

        private void OnDragDropPanelDroped(object sender, DragEventArgs e)
        {
            DragAndDrop.Drop(e);
            UnzipAndConvertFile(DragAndDrop.Drop(e));
        }
        
        private void UnzipAndConvertFile(string pathToTxt)
        { 
            try
            {
                DragDropLabel.Text = "Drag and Drop";

                ChatRichTextBox.Clear();
                ChatMembersRrichTextBox.Clear();

                string strWholeFile = (WhatsAppArchive.UnzipAndReadFile(pathToTxt));

                SelectPersonForm SelectPersonForm = new SelectPersonForm();
                SelectPersonForm.ShowDialog();

                var ChatMembers = WhatsAppArchiveReader.PersonList.ChatMembers;
                if (ChatMembers != null && ChatMembers.Count != 0)
                {
                    ChatMembersRrichTextBox.Text = String.Join(", ", ChatMembers.ToArray());
                }

                string[] arrMessages = Regex.Split(strWholeFile, "\n");
                string dateTime = String.Empty;

                foreach (string strMessage in arrMessages)
                {
                    if (strMessage != null && !strMessage.Equals(""))
                    {
                        Style.IndentBetweenMessages(ChatRichTextBox);

                        if (!(dateTime.Equals(MessageLines.ExtractDate(strMessage))))
                        {
                            dateTime = MessageLines.ExtractDate(strMessage);
                            Style.Date(ChatRichTextBox, dateTime);
                            Style.IndentBetweenMessages(ChatRichTextBox);
                        }

                        if (MessageLines.ExtractName(strMessage).Equals(PersonList.SelectedPerson))
                        {
                            Style.MyMessage(ChatRichTextBox, strMessage);
                        }
                        else
                        {
                            Style.ChatMembersMessage(ChatRichTextBox, strMessage);
                        }
                    }
                }
                ChatRichTextBox.Focus();
                ChatRichTextBox.Select(ChatRichTextBox.Text.Length, 0);
            }
            catch
            {
                MessageBox.Show("Не удалось распознать файл архива WhatsApp", "Ошибка");
            }
        }            
    }
}
