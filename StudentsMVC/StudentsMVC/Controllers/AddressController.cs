using StudentsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsMVC.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        public ActionResult Index()
        {
            return View(MvcApplication.addressList);
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            var address = MvcApplication.addressList.Where(s => s.Id == id).FirstOrDefault();

            return View(address);
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
                address.Id = ++MvcApplication.addressesIdCount;
                MvcApplication.addressList.Add(address);

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
            var address = MvcApplication.addressList.Where(s => s.Id == id).FirstOrDefault();

            return View(address);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(Address address)
        {
            try
            {
                // TODO: Add update logic here
               var ad = MvcApplication.addressList.Where(s => s.Id == address.Id).FirstOrDefault();
                ad.Street = address.Street;
                ad.City = address.City;
                ad.PostalCode = address.PostalCode;

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
            var address = MvcApplication.addressList.Where(s => s.Id == id).FirstOrDefault();

            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var address = MvcApplication.addressList.Where(s => s.Id == id).FirstOrDefault();
                MvcApplication.addressList.Remove(address);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
