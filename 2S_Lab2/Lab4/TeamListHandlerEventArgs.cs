using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class TeamListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public int NumberOfElem { get; set; }

        public TeamListHandlerEventArgs()
        {
            CollectionName = "Name";
            ChangeType = "None";
            NumberOfElem = 0;
        }
        public TeamListHandlerEventArgs(string name, string type, int num)
        {
            CollectionName = name;
            ChangeType = type;
            NumberOfElem = num;
        }

        public override string ToString()
        {
            string info = "\nName of collection: " + CollectionName + "\nType of changes: " + ChangeType + "\nNumber of element: " + NumberOfElem;
            return info;
        }
    }
}
