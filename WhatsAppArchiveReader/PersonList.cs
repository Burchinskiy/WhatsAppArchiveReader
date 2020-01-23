using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppArchiveReader
{
    static class PersonList
    {
        public static List<string> Persons { get; set; }
        public static string SelectedPerson { get; set; }
        public static List<string> ChatMembers { get; set; }
        
        public static void ClearPersonList()
        {
            SelectedPerson = null;

            Persons?.Clear();
            ChatMembers?.Clear();
        }
    }               
}
