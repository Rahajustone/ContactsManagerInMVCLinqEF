using ContactsManagerInMVCLinqEF.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactsManagerInMVCLinqEF.Areas.Admin.Controllers
{
    public class CountryController : Controller
    {
        //
        // GET: /Admin/Country/
        CountryBO objCountryBO = new CountryBO();
        public ActionResult Manage()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View(objCountryBO.GetCountries());
        }
        //
        // GET: /Admin/Country/Details/5
        public ActionResult Details(int id = 0)
        {
            Country country = objCountryBO.GetCountry(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }
        //
        // GET: /Admin/Country/Create
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Admin/Country/Create
        [HttpPost]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                objCountryBO.InsertCountry(country);
                return RedirectToAction("Index");
            }
            return View(country);
        }
        //
        // GET: /Admin/Country/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Country country = objCountryBO.GetCountry(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }
        //
        // POST: /Admin/Country/Edit/5
        [HttpPost]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                objCountryBO.UpdateCountry(country);
                return RedirectToAction("Index");
            }
            return View(country);
        }
        //
        // GET: /Admin/Country/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Country country = objCountryBO.GetCountry(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }
        //
        // POST: /Admin/Country/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            objCountryBO.DeleteCountry(id);
            return RedirectToAction("Index");
        }
    }
}