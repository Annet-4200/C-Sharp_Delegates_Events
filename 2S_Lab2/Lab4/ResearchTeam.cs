using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public enum Revision { Remove, Replace, Property };
    public delegate void ResearchTeamsChangedHandler<TKey>(object source, ResearchTeamsChangedEventArgs<TKey> args);

    class ResearchTeam : Team, INameAndCopy, IComparer<ResearchTeam>, INotifyPropertyChanged
    {
        private string topic;   //Тема исследований
        private TimeFrame time;     //Продолжительность исследований
        private List<Paper> paper = new List<Paper>();
        private List<Person> person = new List<Person>();
        public event PropertyChangedEventHandler PropertyChanged;

        public string Topic
        {
            get { return topic; }
            set
            {
                topic = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Тема исследований"));
            }
        }
        public TimeFrame Time
        {
            get { return time; }
            set
            {
                time = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Продолжительность исследований"));
            }
        }
        public List<Paper> Paper
        {
            get { return paper; }
            set { paper = value; }
        }
        public List<Person> Person
        {
            get { return person; }
            set { person = value; }
        }
        public Team Team  // возвращает тип team если данные совпадают с данными подобъекта
        {
            get { return new Team(name, reNumber); }
            set
            {
                name = value.Name;
                reNumber = value.ReNumber;
            }
        }
        int counter;

        public Paper Last
        {
            get
            {
                if (paper != null)
                {
                    DateTime last = new DateTime(2000, 01, 01);
                    for (int i = 0; i < paper.Count; i++)
                    {
                        if (last < paper[i].Date)
                        {
                            last = paper[i].Date;
                            counter = i;
                        }
                    }
                    return paper[counter];
                }
                else
                {
                    return null;
                }
            }

        }

        public ResearchTeam()
        {
            Topic = "NO_TOPIC";
            Time = TimeFrame.Year;
        }

        public ResearchTeam(string topic, string name, int reNum, TimeFrame time) : base(name, reNum)
        {
            Topic = topic;
            Time = time;

        }

        public void AddPapers(params Paper[] newPaper)
        {
            paper.AddRange(newPaper);
        }
        public void AddMembers(params Person[] newPerson)
        {
            person.AddRange(newPerson);
        }

        public override string ToString()
        {
            string info = "\nTopic: " + topic + "\nOrganization " + Name + "\nRegistration number: " + reNumber + "\nDuration: " + time + "\nList of publications: ";
            for (int i = 0; i < paper.Count; i++)
            {
                info += "\n\n" + (i + 1) + ") " + paper[i];
            }
            info += "\n\nList of members: ";
            for (int i = 0; i < person.Count; i++)
            {
                info += "\n\n" + (i + 1) + ") " + person[i];
            }
            return info;
        }

        public virtual string ToShortString()
        {
            string info = "\nTopic: " + topic + "\nOrganization " + Name + "\nRegistration number: " + reNumber + "\nDuration: " + time;
            return info;
        }
        public override object DeepCopy()
        {
            List<Paper> copyPaper = new List<Paper>();
            List<Person> copyPerson = new List<Person>();
            foreach (Paper p in paper)
            {
                copyPaper.Add((Paper)p.DeepCopy());
            }
            foreach (Person s in person)
            {
                copyPerson.Add((Person)s.DeepCopy());
            }
            ResearchTeam r1 = new ResearchTeam(topic, name, reNumber, time)
            {
                paper = copyPaper,
                person = copyPerson
            };
            return r1;

        }
        public IEnumerable<Person> NoPublic() // Выводит учасников без публикаций
        {
            foreach (Person p in Person)
            {
                bool flag = false;
                foreach (Paper pap in Paper)
                {
                    if (p == pap.Person)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                    yield return p;
            }
        }
        public IEnumerable<Paper> LastPublic(int years)
        {
            foreach (Paper p in Paper)
            {
                if (DateTime.Now.Year - years <= p.Date.Year)
                    yield return p;
            }

        }
        int IComparer<ResearchTeam>.Compare(ResearchTeam x, ResearchTeam y) // Cравнение по теме публикации
        {
            return x.topic.CompareTo(y.topic);
        }
    }
}
