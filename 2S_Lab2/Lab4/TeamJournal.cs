using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class TeamsJournal<TKey>
    {
        private List<TeamsJournalEntry> teamjournallist;

        public TeamsJournal()
        {
            teamjournallist = new List<TeamsJournalEntry>(); 
        }

        public void TeamChanged(object sender, ResearchTeamsChangedEventArgs<TKey> e) //Обработчик событий
        {
            teamjournallist.Add(new TeamsJournalEntry(e.CollectionName, e.ChangeType, e.NumberOfElem, e.GetRevision));
        }

        public override string ToString()
        {
            string list = "";
            for (int i = 0; i < teamjournallist.Count; i++)
            {
                list +=  $"\n\n{i+1})" + teamjournallist[i];
            }
            return "Events:" + list;
        }
    }
}
