using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class ResearchTeamCollection<TKey>
    {
        public event ResearchTeamsChangedHandler<TKey> ResearchTeamsChanged;
        public Dictionary<TKey, ResearchTeam> resTeam = new Dictionary<TKey, ResearchTeam>();       
        public string CollectionName { get; set; }

        public void AddDefaults(TKey key)
        {
            resTeam.Add(key,new ResearchTeam());         
        }
        public void AddResearchTeams(TKey key, ResearchTeam newteam)
        {
            resTeam.Add(key,newteam);
            newteam.PropertyChanged += ResearchTeamChangedInto;
        }

        public void ResearchTeamChangedInto(object sender, PropertyChangedEventArgs e) //обработчик события изменений свойств
        {
            int num = resTeam.First(i => i.Value==(ResearchTeam)sender).Value.ReNumber;
            ResearchTeamsChanged?.Invoke(this, new ResearchTeamsChangedEventArgs<TKey>(CollectionName, Revision.Property, e.PropertyName,num));
        }

        public bool Remove(ResearchTeam rt)
        {
            if (!resTeam.ContainsValue(rt)) return false;
            else
            {
                foreach (var item in resTeam.Where(kpv => kpv.Value.Equals(rt)).ToList())
                {
                    resTeam.Remove(item.Key);
                    item.Value.PropertyChanged -= ResearchTeamChangedInto;
                    ResearchTeamsChanged?.Invoke(this, new ResearchTeamsChangedEventArgs<TKey>(CollectionName, Revision.Remove, " ", rt.ReNumber));
                }
                return true;
            }
        }

        public bool Replace(ResearchTeam rtold, ResearchTeam rtnew)
        {
            if (!resTeam.ContainsValue(rtold)) return false;
            else
            {
                foreach (var item in resTeam.Where(kpv => kpv.Value.Equals(rtold)).ToArray())
                {
                    resTeam[item.Key] = rtnew;
                    rtold.PropertyChanged -= ResearchTeamChangedInto;
                    rtnew.PropertyChanged += ResearchTeamChangedInto;
                    ResearchTeamsChanged?.Invoke(this, new ResearchTeamsChangedEventArgs<TKey>(CollectionName, Revision.Replace, " ", rtnew.ReNumber));
                }
                return true;
            }
        }
        public int CountOfJournals (int left, int right)
        {
            return  resTeam.Values.Where(r => (r.ReNumber >= left && r.ReNumber <= right)).Count();
        }
        public ResearchTeam this[TKey index] //Индексатор
        {
            get
            {
                return resTeam[index];
            }

            set
            {
                resTeam[index] = value;
            }
        }

    }
}
