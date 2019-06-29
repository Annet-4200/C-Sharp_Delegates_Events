using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
 
    public class ResearchTeamsChangedEventArgs<TKey> : EventArgs
    {
            public string CollectionName { get; set; }
            public string ChangeType { get; set; }
            public Revision GetRevision { get; set; }
            public int NumberOfElem { get; set; }

            public ResearchTeamsChangedEventArgs()
            {
                CollectionName = "Name";
                ChangeType = "None";
                NumberOfElem = 0;
                GetRevision = 0;
            }
            public ResearchTeamsChangedEventArgs(string name,Revision revision, string type, int num)
            {
                CollectionName = name;
                GetRevision = revision;
                ChangeType = type;
                NumberOfElem = num;
            }

            public override string ToString()
            {
                string info = "\nName of collection: " + CollectionName + "\nType of changes: " + ChangeType + "\n" +GetRevision + "\nNumber of element: " + NumberOfElem;
                return info;
            }
    }
}
