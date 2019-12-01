using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsAppArchiveReader
{
    public partial class SelectPersonForm : Form
    {
        public SelectPersonForm()
        {
            InitializeComponent();
            PersonList.Items.AddRange(WhatsAppArchiveReader.PersonList.Persons.ToArray());
        }

        private void OnPersonListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.PersonList.SelectedItems.Count != 0)
            {
                WhatsAppArchiveReader.PersonList.SelectedPerson = PersonList.SelectedItem.ToString();

                var Persons = WhatsAppArchiveReader.PersonList.Persons;
                var SelectedPerson = WhatsAppArchiveReader.PersonList.SelectedPerson;

                WhatsAppArchiveReader.PersonList.ChatMembers = Persons.Where(i => !i.Equals(SelectedPerson)).ToList();
            }
            this.Close();
        }
    }
}
