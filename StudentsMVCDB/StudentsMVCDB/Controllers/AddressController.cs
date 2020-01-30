using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentsMVCDB.Models;

namespace StudentsMVCDB.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        public ActionResult Index()
        {
            return View(DBUtility.SelectAllAddressesAsList(DBUtility.SelectAllAddresses()));
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            return View(DBUtility.SelectAddressById(id));
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(Address address)
        {
            try
            {
                // TODO: Add insert logic here
                if(DBUtility.InsertAddress(address) != 1)
                {
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            return View(DBUtility.SelectAddressById(id));
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Address address)
        {
            try
            {
                // TODO: Add update logic here

                if(DBUtility.UpdateAddress(address) != 1)
                {
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
