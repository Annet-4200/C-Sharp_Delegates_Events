using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Person
    {
        private string firstName; //Имя
        private string secondName; //Фамилия
        private DateTime date; //Дата рождения

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int ChangingYear
        {
            get { return date.Year; }
            set { date = new DateTime(value, date.Month, date.Day); }
        }

        public Person(string firstName, string secondName, DateTime date)
        {
            FirstName = firstName;
            SecondName = secondName;
            Date = date;
        }
        public Person()
        {
            firstName = "Ann";
            secondName = "Ageeva";
            date = new DateTime(2000, 04, 29);
        }
        public override string ToString()
        {
            string info = "\nFirst name: " + firstName + "\nSurname: " + secondName + "\nDate of Birth: " + date;
            return info;
        }
        public virtual string ToShortString()
        {
            string info = "\nFirst name: " + firstName + "\nSurname: " + secondName;
            return info;
        }
        public override bool Equals(object obj)
        {
            if (obj is Person p1)
            {
                return ToString() == obj.ToString();
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(Person p1, Person p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !p1.Equals(p2);
        }
        public virtual object DeepCopy()
        {
            Person p1 = new Person(firstName, secondName, date);
            return p1;
        }
    }
}
