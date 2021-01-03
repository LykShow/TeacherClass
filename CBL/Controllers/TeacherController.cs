using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CBL
{
   public class TeacherController
    {
        public List<Teacher> teachers = new List<Teacher>();
        
        public string Path = $"{Environment.CurrentDirectory}\\TeavherList.json";
        public LoadAndSave<Teacher> las;
        public ClassController classController;
        public Teacher teacher;
        public bool Complete { get; set; } = false;
        public TeacherController()
        {
           las = new LoadAndSave<Teacher>(Path);
           teachers = las.Load();
            if(teachers == null)
            {
                teachers= new List<Teacher>();
            }
        }
        public Teacher LoadTeacher(string name, string soname)
        {
            
            teacher = teachers.SingleOrDefault(s => s.Name == name || s.SoName == soname);
            
            return teacher;
            
        }
        public void SetClassControll()
        {
            classController = new ClassController(teacher);
        }
        public void AddTeacher(string name, string soname, string gender, DateTime birthday, string clas, int id)
        {
            teachers.Add(new Teacher(name, soname, gender, birthday, clas,id));
            las.Save(teachers);
        }
    }
}
