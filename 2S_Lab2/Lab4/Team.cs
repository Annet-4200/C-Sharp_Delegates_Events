using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Team : INameAndCopy, IComparable
    {
        protected string name; // Название организвции
        protected int reNumber; // Регистрационный номер

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ReNumber
        {
            get { return reNumber; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("Registration number can't be <= 0");
                else reNumber = value;
            }
        }
        public Team()
        {
            Name = "Book Club";
            ReNumber = 1111;
        }
        public Team(string org, int reNum)
        {
            Name = org;
            ReNumber = reNum;
        }

        public override string ToString()
        {
            string info = "\nName of organization: " + name + "\nRegistration number: " + reNumber;
            return info;
        }

        public override bool Equals(object obj)
        {
            if (obj is Team t1)
            {
                return ToString() == obj.ToString();
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(Team t1, Team t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(Team t1, Team t2)
        {
            return !t1.Equals(t2);
        }

        public virtual object DeepCopy()
        {
            Team t1 = new Team(name, reNumber);
            return t1;

        }

         int IComparable.CompareTo(object obj)
        {
            if (obj is Team t1)
            {
                if (reNumber > t1.reNumber)
                    return 1;
                if (reNumber < t1.reNumber)
                    return -1;
                else return 0;
            }
            else throw new ArgumentException("Parametr is not Team");
        }
    }
}
