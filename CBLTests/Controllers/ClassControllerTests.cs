using Microsoft.VisualStudio.TestTools.UnitTesting;
using CBL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBL.Tests
{
    [TestClass()]
    public class ClassControllerTests
    {
       
        [TestMethod()]
        public void AddClassTest()
        {
            //Arrange
            var number = "11 A";
            var name = Guid.NewGuid().ToString();
            var soname = Guid.NewGuid().ToString();
            var gender = Guid.NewGuid().ToString();
            var birtgay = DateTime.Now.AddYears(-18);
            var clas = "11 A";
            var id = 10;
            var teachcontroller = new TeacherController();



            //Act
            teachcontroller.AddTeacher(name, soname, gender, birtgay, clas, id);
           teachcontroller.LoadTeacher(name, soname);
            teachcontroller.SetClassControll();
            
            teachcontroller.classController.AddClass(number);
            

          
            //Assert
            Assert.AreEqual(teachcontroller.classController.classes[0].Number, number);



            

        }

        [TestMethod()]
        public void AddStudentTest()
        {
            //Arrange
            var number = "11 A";
            var name = Guid.NewGuid().ToString();
            var soname = Guid.NewGuid().ToString();
            var gender = Guid.NewGuid().ToString();
            var birtgay = DateTime.Now.AddYears(-18);
            var clas = "11 A";
            var id = 10;
            var teachcontroller = new TeacherController();



            //Act
            teachcontroller.AddTeacher(name, soname, gender, birtgay, clas, id);
            teachcontroller.LoadTeacher(name, soname);
            teachcontroller.SetClassControll();
            
            teachcontroller.classController.AddClass(number);
            teachcontroller.classController.AddStudent(number, name, soname, gender, birtgay);
           
            //Assert
            Assert.AreEqual(teachcontroller.classController.Currentclass.students[0].Name, name);
        }
      
       

        [TestMethod()]
        public void LoadClassTest()
        {
            //Arange
            var number = "11 A";
            var name = Guid.NewGuid().ToString();
            var soname = Guid.NewGuid().ToString();
            var gender = Guid.NewGuid().ToString();
            var birtgay = DateTime.Now.AddYears(-18);
            var clas = "11 A";
            var id = 10;
            var teachcontroller = new TeacherController();



            //Act
            teachcontroller.AddTeacher(name, soname, gender, birtgay, clas, id);
            var teacher = teachcontroller.LoadTeacher(name, soname);
            teachcontroller.SetClassControll();

            teachcontroller.classController.AddClass(number);
            teachcontroller.classController.AddStudent(number, name, soname, gender, birtgay);
            var cl = teachcontroller.classController.LoadClass(number);

            //Assert
            Assert.AreEqual(cl, teachcontroller.classController.Currentclass);
        }
    }
}