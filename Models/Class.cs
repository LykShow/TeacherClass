using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CBL
{
   public class Class { 
        public string Number { get; }
        public int Id { get; set; }
        public List<Student> students = new List<Student>();
        public Teacher teacher { get; }
        public Class(string number, int id, Teacher teacher)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException("Заполните это поле", nameof(number));
            }
            if (teacher == null)
            {
                throw new ArgumentNullException("Не существует", nameof(teacher));
            }
            if (students == null)
            {
                students = new List<Student>();
            }
            if (id == 0)
            {
                throw new ArgumentNullException("Заполните это поле", nameof(id));
            }
            Number = number;
            Id = id;
            this.teacher = teacher;
        }
        public override string ToString()
        {
            return Number;
        }

    }
}
