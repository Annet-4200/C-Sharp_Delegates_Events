using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class TestCollections
    {
        private List<Team> teamList; 
        private List<string> stringList;
        private Dictionary<Team, ResearchTeam> teamDic;
        private Dictionary<string, ResearchTeam> stringDic;
        
        static ResearchTeam AutoGeneric(int k) //инициализация элементов 
        {
            ResearchTeam rs = new ResearchTeam($"Topic{k}", $"Team{k}", k, TimeFrame.TwoYears);
            return rs;
        }
        public TestCollections(int k) // конструктор класса
        {
            teamList = new List<Team>();
            stringList = new List<string>();
            teamDic = new Dictionary<Team, ResearchTeam>();
            stringDic = new Dictionary<string, ResearchTeam>();
            for (int i = 1; i < k+1; i++)
            {
                teamList.Add(AutoGeneric(i).Team);
                stringList.Add(AutoGeneric(i).Team.ToString());
                teamDic.Add(AutoGeneric(i).Team, AutoGeneric(i));
                stringDic.Add(AutoGeneric(i).Team.ToString(), AutoGeneric(i));
            }
        }
        public void Search(int k)
        {
            int x, y, res;
            bool ch =false;
            ResearchTeam rt = AutoGeneric(k);

            x = Environment.TickCount;
            ch = teamList.Contains(rt.Team);
            y = Environment.TickCount;
            res = y - x;
            Console.WriteLine("List<Team> = {0} ms",res);
            Console.WriteLine("Found? " + ch);

            x = Environment.TickCount;
            ch = stringList.Contains(rt.Team.ToString());
            y = Environment.TickCount;
            res = y - x;
            Console.WriteLine("List<string> = {0} ms", res);
            Console.WriteLine("Found? " + ch);

            x = Environment.TickCount;
            ch = teamDic.ContainsKey(rt.Team);
            y = Environment.TickCount;
            res = y - x;
            Console.WriteLine("Key - Dictionary<Team, ResearchTeam> = {0} ms", res);
            Console.WriteLine("Found? " + ch);

            x = Environment.TickCount;
            ch = teamDic.ContainsValue(rt);
            y = Environment.TickCount;
            res = y - x;
            Console.WriteLine("Key - Dictionary<Team, ResearchTeam> = {0} ms", res);
            Console.WriteLine("Found? " + ch);

            x = Environment.TickCount;
            ch = stringDic.ContainsKey(rt.Team.ToString());
            y = Environment.TickCount;
            res = y - x;
            Console.WriteLine("Dictionary<string, ResearchTeam> = {0} ms", res);
            Console.WriteLine("Found? " + ch);

            x = Environment.TickCount;
            ch = stringDic.ContainsValue(rt);
            y = Environment.TickCount;
            res = y - x;
            Console.WriteLine("Dictionary<string, ResearchTeam> = {0} ms", res);
            Console.WriteLine("Found? " + ch);
        }   
    }
}
 