using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CBL
{
   public class ClassController
    {
        public List<Class> classes = new List<Class>();
        public Class Currentclass;
        public string number;
        public string Path = $"{Environment.CurrentDirectory}\\ClassList.json";
        public Teacher current;
        public LoadAndSave<Class> las;
        public ClassController(Teacher teacher)
        {
            current = teacher;
            las = new LoadAndSave<Class>(Path);
            classes = las.Load();
            if(classes == null)
            {
                classes = new List<Class>();
            }
        }
        public void AddClass(string number)
        {
            
            classes.Add(new Class(number, current.Id, current));
            
        }
        public void AddStudent(string number, string name, string soname, string gender, DateTime birtday)
        {
            Currentclass = classes.SingleOrDefault(s => s.Number == number);
            Currentclass.students.Add(new Student(name, soname, gender, birtday, current));
            
        }
        public void DeletStudent(int n)
        {
            n--;
            Currentclass.students.RemoveAt(n);
            SaveClass();
        }
        public void DeletClass(string number)
        {
            Class cl = classes.SingleOrDefault(s => s.Number == number);
            classes.Remove(cl);
            SaveClass();
        }
        public void SaveClass()
        {
            las.Save(classes);
        }
        public Class LoadClass(string number1)
        {           
            Currentclass = classes.SingleOrDefault(s => s.Number == number1&&s.teacher.Name==current.Name&&s.teacher.SoName==current.SoName);
            return Currentclass;
        }
    }
}
