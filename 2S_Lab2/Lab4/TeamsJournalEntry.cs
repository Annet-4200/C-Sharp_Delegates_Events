using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class TeamsJournalEntry
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public Revision GetRevision { get; set; }
        public int NumberOfElem { get; set; }

        public TeamsJournalEntry()
        {
            CollectionName = "Name";
            ChangeType = "None";
            NumberOfElem = 0;
            GetRevision = 0;
        }
        public TeamsJournalEntry(string name, string type, int num, Revision rev)
        {
            CollectionName = name;
            ChangeType = type;
            NumberOfElem = num;
            GetRevision = rev;
        }

        public override string ToString()
        {
            string info = "Name of collection: " + CollectionName + "\nType of changes: " + ChangeType + "\n" + GetRevision + "\nNumber of element: " + NumberOfElem;
            return info;
        }
    }
}
