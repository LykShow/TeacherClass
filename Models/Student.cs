using System;
using System.Collections.Generic;
using System.Text;

namespace CBL
{
   public class Student:Person
    {                    
        public Teacher teacher { get; }

        public Student(string name, string soName, string gender, DateTime birtDay, Teacher teacher):base(name, soName, gender, birtDay)
        {
            if(teacher == null)
            {
                throw new ArgumentNullException("Не существует", nameof(teacher));
            }
            this.teacher = teacher;
        }
        
        public override string ToString()
        {
            return Name + " " + SoName+" "+ Age+" "+gender;

        }
    }
}
