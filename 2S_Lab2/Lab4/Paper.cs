using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Paper : INameAndCopy
    {
        public string Name { get; set; } //Название публикации
        public Person Person { get; set; } //Автор публикации
        public DateTime Date { get; set; } //Дата публикации

        public Paper(string name, Person person, DateTime date)
        {
            Name = name;
            Person = person;
            Date = date;
        }

        public Paper()
        {
            Name = "Novel_42";
            Person = new Person();
            Date = new DateTime(2018, 04, 29);
        }

        public override string ToString()
        {
            string info = "Name: " + Name + "\nAuthor - " + Person + "\nDate of publication: " + Date;
            return info;
        }

        public virtual object DeepCopy()
        {
            Paper p1 = new Paper(Name, new Person(Person.FirstName, Person.SecondName, Person.Date), Date);
            return p1;

        }
    }
}
