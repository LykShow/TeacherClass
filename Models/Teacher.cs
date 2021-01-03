using System;

namespace CBL
{
    public class Teacher:Person
    {                        
        public string Clas { get; set; }
        public int Id { get; set; }


        public Teacher(string name, string soname, string gender, DateTime birthDay, string clas, int id) : base(name, soname, gender, birthDay)
        {
            if (string.IsNullOrWhiteSpace(clas))
            {
                throw new ArgumentNullException("Заполните это поле", nameof(clas));
            }
            if (id==0)
            {
                throw new ArgumentNullException("Заполните это поле", nameof(id));
            }
            Clas = clas;
            Id = id;
        }
        
        public override string ToString()
        {
            return Name + " " + SoName+" "+Age+", "+Clas; 

        }

    }
}
