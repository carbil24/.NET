using StudentsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View(MvcApplication.studentList);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = MvcApplication.classroomList.Where(s => s.Id == id).FirstOrDefault();

            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            List<int> ListOfClassrooms = new List<int>();
            foreach (var item in MvcApplication.classroomList)
            {
                ListOfClassrooms.Add(item.Id);
            }
            ViewBag.ListOfClassrooms = ListOfClassrooms;

            List<int> ListOfAddresses = new List<int>();
            foreach (var item in MvcApplication.addressList)
            {
                ListOfAddresses.Add(item.Id);
            }
            ViewBag.ListOfAddresses = ListOfAddresses;
            return View();
        }
        

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Classroom classroom, Student student)
        {
            try
            {
                // TODO: Add insert logic here

                student.Id = ++MvcApplication.studentsIdCount;

                var cs = MvcApplication.classroomList.Where(s => s.Id == classroom.Id).FirstOrDefault();

                student.StudentClassroom.Id = cs.Id;
                student.StudentClassroom.Name = cs.Name;
                student.StudentClassroom.Number = cs.Number;

                MvcApplication.studentList.Add(student);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = MvcApplication.studentList.Where(s => s.Id == id).FirstOrDefault();

            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                // TODO: Add update logic here
                var st = MvcApplication.studentList.Where(s => s.Id == student.Id).FirstOrDefault();
                st.StudentName = student.StudentName;
                st.Age = student.Age;
                st.StudentClassroom = student.StudentClassroom;
                st.StudentAddress = student.StudentAddress;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = MvcApplication.studentList.Where(s => s.Id == id).FirstOrDefault();

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var student = MvcApplication.studentList.Where(s => s.Id == id).FirstOrDefault();
                MvcApplication.studentList.Remove(student);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
