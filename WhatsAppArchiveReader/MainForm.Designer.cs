namespace WhatsAppArchiveReader
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.DragDropPanel = new System.Windows.Forms.Panel();
            this.DragDropLabel = new System.Windows.Forms.Label();
            this.ChatMembersRrichTextBox = new System.Windows.Forms.RichTextBox();
            this.DragDropPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatRichTextBox
            // 
            this.ChatRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(232)))), ((int)(((byte)(223)))));
            this.ChatRichTextBox.Location = new System.Drawing.Point(159, 68);
            this.ChatRichTextBox.Name = "ChatRichTextBox";
            this.ChatRichTextBox.Size = new System.Drawing.Size(771, 413);
            this.ChatRichTextBox.TabIndex = 4;
            this.ChatRichTextBox.Text = "";
            this.ChatRichTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.OnChatRichTextBoxLinkClicked);
            // 
            // DragDropPanel
            // 
            this.DragDropPanel.AllowDrop = true;
            this.DragDropPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DragDropPanel.Controls.Add(this.DragDropLabel);
            this.DragDropPanel.Location = new System.Drawing.Point(12, 12);
            this.DragDropPanel.Name = "DragDropPanel";
            this.DragDropPanel.Size = new System.Drawing.Size(136, 469);
            this.DragDropPanel.TabIndex = 6;
            this.DragDropPanel.Click += new System.EventHandler(this.OnDragDropPanelClicked);
            this.DragDropPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDropPanelDroped);
            this.DragDropPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragDropPanelEntered);
            this.DragDropPanel.DragLeave += new System.EventHandler(this.OnDragDropPanelLeaved);
            this.DragDropPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDragDropPanelPainted);
            // 
            // DragDropLabel
            // 
            this.DragDropLabel.AllowDrop = true;
            this.DragDropLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DragDropLabel.AutoSize = true;
            this.DragDropLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DragDropLabel.ForeColor = System.Drawing.Color.SlateGray;
            this.DragDropLabel.Location = new System.Drawing.Point(7, 216);
            this.DragDropLabel.Name = "DragDropLabel";
            this.DragDropLabel.Size = new System.Drawing.Size(115, 17);
            this.DragDropLabel.TabIndex = 0;
            this.DragDropLabel.Text = "Drag and Drop";
            this.DragDropLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChatMembersRrichTextBox
            // 
            this.ChatMembersRrichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatMembersRrichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(94)))), ((int)(((byte)(85)))));
            this.ChatMembersRrichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatMembersRrichTextBox.ForeColor = System.Drawing.Color.White;
            this.ChatMembersRrichTextBox.Location = new System.Drawing.Point(159, 12);
            this.ChatMembersRrichTextBox.Name = "ChatMembersRrichTextBox";
            this.ChatMembersRrichTextBox.Size = new System.Drawing.Size(771, 60);
            this.ChatMembersRrichTextBox.TabIndex = 8;
            this.ChatMembersRrichTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 493);
            this.Controls.Add(this.ChatMembersRrichTextBox);
            this.Controls.Add(this.DragDropPanel);
            this.Controls.Add(this.ChatRichTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WhatsApp Archive Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormClosing);
            this.DragDropPanel.ResumeLayout(false);
            this.DragDropPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox ChatRichTextBox;
        private System.Windows.Forms.Panel DragDropPanel;
        private System.Windows.Forms.Label DragDropLabel;
        private System.Windows.Forms.RichTextBox ChatMembersRrichTextBox;
    }
}

