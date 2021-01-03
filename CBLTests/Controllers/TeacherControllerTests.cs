using Microsoft.VisualStudio.TestTools.UnitTesting;
using CBL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CBL.Tests
{
    [TestClass()]
    public class TeacherControllerTests
    {
        
        [TestMethod()]
        public void LoadTeacherTest()
        { //Arrange
            var name = Guid.NewGuid().ToString();
            var soname = Guid.NewGuid().ToString();
            var teachcontroller = new TeacherController();
            //Act
            var teacher = teachcontroller.LoadTeacher(name, soname);
            //Assert
            Assert.AreEqual(teacher, teachcontroller.teacher);
        }

        [TestMethod()]
        public void SetClassControllTest()
        {
            var name = Guid.NewGuid().ToString();
            var soname = Guid.NewGuid().ToString();
            var teachcontroller = new TeacherController();
            //Act
            var teacher = teachcontroller.LoadTeacher(name, soname);
            teachcontroller.SetClassControll();
            var classcontroll = new ClassController(teacher);
            //Assert
            Assert.AreEqual(classcontroll.current, teachcontroller.classController.current);
        }

        [TestMethod()]
        public void AddTeacherTest()
        {
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
            var teachcontroller2 = new TeacherController();
            var teacher2 = teachcontroller2.LoadTeacher(name, soname);

            //Assert
            Assert.AreEqual(teacher.Name, teacher2.Name);
            Assert.AreEqual(teacher.SoName, teacher2.SoName);
            Assert.AreEqual(teacher.gender,teacher2.gender);
            Assert.AreEqual(teacher.BirtDay,teacher2.BirtDay);
            
           
        }
    }
}