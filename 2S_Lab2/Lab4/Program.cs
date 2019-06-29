using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {

            ResearchTeam pz = new ResearchTeam("Family", "409 Production", 1234, TimeFrame.Year);
            ResearchTeam px = new ResearchTeam("Help", "Me", 103, TimeFrame.Long);
            ResearchTeam pxx = new ResearchTeam("Help", "Me", 505, TimeFrame.Long);

            Paper[] newPapers = { //Список новых публикаций
                new Paper("Goddess of Math",new Person(), new DateTime(2015,02,02)),
                new Paper("FSB", new Person ("Alina", "Ruchinskaya",new DateTime(1999,12,03)), new DateTime(2017,11,06)),
                new Paper("Kotja", new Person ("Eugene", "Gerasimov", new DateTime(2000,01,30)), new DateTime(2016,03,20))
            };
            Person[] newPerson = {
                new Person(),
                new Person("Alina", "Ruchinskaya", new DateTime(1999, 12, 03)),
                new Person("Eugene", "Gerasimov", new DateTime(2000, 01, 30)),
                new Person("Lina", "Antonenko", new DateTime(2000,07,19))
            };

            pz.AddPapers(newPapers);  //Добавляем новые публикации и учасников
            pz.AddMembers(newPerson);
            ResearchTeamCollection<string> rtc1 = new ResearchTeamCollection<string>
            {
                CollectionName = "First collection"
            };
            ResearchTeamCollection<string> rtc2 = new ResearchTeamCollection<string>
            {
                CollectionName = "Second collection"
            };
            TeamsJournal<string> tg1 = new TeamsJournal<string>();
            rtc1.ResearchTeamsChanged += tg1.TeamChanged;  //подписка
            rtc2.ResearchTeamsChanged += tg1.TeamChanged;

            rtc1.AddDefaults("150"); // добавление элементов
            rtc2.AddResearchTeams("120",pxx);
            rtc1.AddResearchTeams("17", pz);
            rtc1.AddResearchTeams("188", px);
            rtc2.AddResearchTeams("18", px);
            rtc1.resTeam["17"].Topic = "NEW TOPIC"; //изменение отдельных свойств 1
            rtc2.resTeam["120"].Time = TimeFrame.Year;  //2
            rtc2.Remove(px); // удаление 3
            px.Topic = "VERY NEW TOPIC"; //4
            rtc1.Replace(pz, pxx);  //5
            pz.Time = TimeFrame.TwoYears;
        
            Console.WriteLine("TEAM JOURNAL:\n" + tg1.ToString());
            Console.WriteLine("Count of journals: " + rtc1.CountOfJournals(0,2000));
            Console.ReadLine();
        }
    }
}
