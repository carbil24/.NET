using StudentsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsMVC.Controllers
{
    public class ClassroomController : Controller
    {
        // GET: Classroom
        public ActionResult Index()
        {
            return View(MvcApplication.classroomList);
        }

        // GET: Classroom/Details/5
        public ActionResult Details(int id)
        {
            var classroom = MvcApplication.classroomList.Where(s => s.Id == id).FirstOrDefault();

            return View(classroom);
        }

        // GET: Classroom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classroom/Create
        [HttpPost]
        public ActionResult Create(Classroom classroom) //FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                classroom.Id = ++MvcApplication.classroomsIdCount;
                MvcApplication.classroomList.Add(classroom);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Classroom/Edit/5
        public ActionResult Edit(int id)
        {

            var classroom = MvcApplication.classroomList.Where(s => s.Id == id).FirstOrDefault();

            return View(classroom);
        }

        // POST: Classroom/Edit/5
        [HttpPost]
        public ActionResult Edit(Classroom classroom)
        {
            try
            {
                // TODO: Add update logic here
                var cs = MvcApplication.classroomList.Where(s => s.Id == classroom.Id).FirstOrDefault();
                cs.Name = classroom.Name;
                cs.Number = classroom.Number;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Classroom/Delete/5
        public ActionResult Delete(int id)
        {
            var classroom = MvcApplication.classroomList.Where(s => s.Id == id).FirstOrDefault();

            return View(classroom);
        }

        // POST: Classroom/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var classroom = MvcApplication.classroomList.Where(s => s.Id == id).FirstOrDefault();
                MvcApplication.classroomList.Remove(classroom);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
