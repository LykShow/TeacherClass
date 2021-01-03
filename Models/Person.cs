using System;
using System.Collections.Generic;
using System.Text;

namespace CBL
{
    public abstract class Person
    {
        public string Name { get; }
        public string SoName { get; }
        public string gender { get; set; }
        public int Age { get; }
        public DateTime BirtDay { get; set; }
        public Person(string name, string soName, string gender, DateTime birtDay)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Заполните это поля", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(soName))
            {
                throw new ArgumentNullException("Заполните это поля", nameof(soName));
            }
            if (string.IsNullOrWhiteSpace(gender))
            {
                throw new ArgumentNullException("Заполните это поля", nameof(gender));
            }
            if (birtDay == null)
            {
                throw new ArgumentNullException("Заполните это поля", nameof(birtDay));
            }
            Name = name;
            SoName = soName;
            BirtDay = birtDay;
            Age = SetAge(birtDay);
            this.gender = gender;
            
            
        }
        public int SetAge(DateTime date)
        {

            int dateTime = DateTime.Today.Year - date.Year;
            return dateTime;
        }
    }
}
