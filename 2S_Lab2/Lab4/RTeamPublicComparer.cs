using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class RTeamPublicComparer : IComparer<ResearchTeam>
    {
        int IComparer<ResearchTeam>.Compare(ResearchTeam r1, ResearchTeam r2)
        {
                return r1.Paper.Count.CompareTo(r2.Paper.Count);
        }
    }
}
