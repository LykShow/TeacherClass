using System;
using CBL;
namespace ClassView
{
    class Program
    {
        static TeacherController teacherController = new TeacherController();

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в электронный журнал учителя ");                       
            Console.WriteLine("Нажмите Q чтобы зарегистрироваться или нажмите E чтобы войти и нажмите Enter");
            string regorenter = Console.ReadLine();

            if (regorenter == "Q")
            {
                Regestration();

            }
            else if (regorenter == "E")
            {
                Enter();
            }
            
            while (true)
            {
                teacherController.SetClassControll();
                ListClass();
                Console.WriteLine("Чтобы посмотреть вваш класс нажмите Q, чтобы добавить класс нажмите E, чтобы удалить класс нажмите W");
                string addorloadcl = Console.ReadLine();
                if (addorloadcl == "Q")
                {
                   LoadClass();
                }
                else if (addorloadcl == "E")
                {
                    AddClass();
                }
                else if (addorloadcl == "W")
                {
                    Console.WriteLine("Введите номер и букву вашего класса");
                    string num = Console.ReadLine();
                    teacherController.classController.DeletClass(num);
                }

            }

        }
        private static void ListClass()
        {
            Console.WriteLine();
            Console.WriteLine("Ваш список классов:");
            
            foreach (Class i in teacherController.classController.classes)
            {
                if (i.teacher.Name == teacherController.teacher.Name && i.teacher.SoName == teacherController.teacher.SoName)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine();
        }
        private static void LoadClass()
        {

                
                Console.WriteLine("Введите номер и букву вашего класса");
                string num = Console.ReadLine();
                Console.WriteLine(teacherController.classController.LoadClass(num));
                Console.WriteLine();
                if (teacherController.classController.Currentclass == null)
                {
                    Console.WriteLine("Не существует");
                    return;
                }
                Console.WriteLine();
                int n = 0;
                foreach (Student i in teacherController.classController.Currentclass.students)
                {
                   
                   n++;
                    Console.WriteLine(n+" "+i);
                }
                Console.WriteLine();
            while (true)
            {

                Console.WriteLine("добавить ученика Да-Q  Удалить учениика Да-W  Отмена-E ");
                string yesornot = Console.ReadLine();

                if (yesornot == "Q")
                {

                    Console.WriteLine("Введите Имя");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите Фамилию");
                    string soname = Console.ReadLine();
                    Console.WriteLine("Введите Пол");
                    string gender = Console.ReadLine();
                    Console.WriteLine("Введите Дату Рождения");
                    DateTime dateTime = DateTime.Parse(Console.ReadLine());

                    teacherController.classController.AddStudent(num, name, soname, gender, dateTime);
                }
                else if(yesornot == "W")
                {
                    Console.WriteLine("Введите номер ученика");
                    int numb = int.Parse(Console.ReadLine());
                    teacherController.classController.DeletStudent(numb);
                }
                else if (yesornot == "E")
                {
                    teacherController.classController.SaveClass();
                    break;
                }
            }


        }
        private static void AddClass()
        {
               Console.WriteLine("Введите номер и букву вашего класса");
                string num = Console.ReadLine();
                teacherController.classController.AddClass(num);
                while (true)
                {

                    Console.WriteLine("Хотите добавить ученика ? Да-Q Нет-E");
                    string yesornot = Console.ReadLine();

                    if (yesornot == "Q")
                    {

                        Console.WriteLine("Введите Имя");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите Фамилию");
                        string soname = Console.ReadLine();
                        Console.WriteLine("Введите Пол");
                        string gender = Console.ReadLine();
                        Console.WriteLine("Введите Дату Рождения");
                        DateTime dateTime = DateTime.Parse(Console.ReadLine());

                        teacherController.classController.AddStudent(num, name, soname, gender, dateTime);
                    }
                    else if (yesornot == "E")
                    {
                        teacherController.classController.SaveClass();
                        break;
                    }
                }
            
        }
        private static void Regestration()
        {
            Console.WriteLine("Введите Имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите Фамилию");
            string soname = Console.ReadLine();
            Console.WriteLine("Введите Пол");
            string gender = Console.ReadLine();
            Console.WriteLine("Введите Дату Рождения");
            DateTime dateTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите Свой класс");
            string clas = Console.ReadLine();
            Console.WriteLine("Введите свой Id");
            int id = int.Parse(Console.ReadLine());
            teacherController.AddTeacher(name, soname, gender, dateTime, clas, id);
        }
        private static void Enter()
        {
            Console.WriteLine("Введите Имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите Фамилию");
            string soname = Console.ReadLine();
            Console.WriteLine(teacherController.LoadTeacher(name, soname));
        }
    }
}
