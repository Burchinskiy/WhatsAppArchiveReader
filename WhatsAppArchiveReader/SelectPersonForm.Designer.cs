namespace WhatsAppArchiveReader
{
    partial class SelectPersonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PersonList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // PersonList
            // 
            this.PersonList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PersonList.FormattingEnabled = true;
            this.PersonList.ItemHeight = 20;
            this.PersonList.Location = new System.Drawing.Point(12, 17);
            this.PersonList.Name = "PersonList";
            this.PersonList.Size = new System.Drawing.Size(388, 344);
            this.PersonList.TabIndex = 0;
            this.PersonList.SelectedIndexChanged += new System.EventHandler(this.OnPersonListSelectedIndexChanged);
            // 
            // SelectPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 373);
            this.Controls.Add(this.PersonList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SelectPersonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите, кто вы в диалоге";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox PersonList;
    }
}