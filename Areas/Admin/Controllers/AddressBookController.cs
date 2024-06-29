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
    public class AddressBookController : Controller
    {
        //
        // GET: /Admin/AddressBook/
        AddressBookBO objAddressBookBO = new AddressBookBO();
        StateBO objStateBO = new StateBO();
        UserBO objUserBO = new UserBO();
        CountryBO objCountryBO = new CountryBO();
        public ActionResult Index()
        {
            ViewBag.FKStateId = new SelectList(objStateBO.GetStates(0, true), "PKStateId", "StateName");
            //var lst = objAddressBookBO.GetAddresses();
            return View(objAddressBookBO.GetAddresses());
        }
        // POST: /Admin/AddressBook/Index
        [HttpPost]
        public ActionResult Index(FormCollection col)
        {
            bool? isActive = null;
            int countryId = 0;
            if (col["PKCountryId"] != "")
                countryId = Convert.ToInt32(col["PKCountryId"]);
            int stateId = Convert.ToInt32(col["FKStateId"]);
            if (col["btnSearch"] == "Search")
            {
                if (col["ShowDropDown"] != "")
                    isActive = Convert.ToBoolean(col["ShowDropDown"]);
                if (isActive == null)
                {
                    var searchaddbook = objAddressBookBO.GetAddresses(countryId, stateId, isActive);
                    ViewBag.FKStateId = new SelectList(objStateBO.GetStates(0, true), "PKStateId", "StateName");
                    return View("Index", searchaddbook);
                }
                else
                {
                    var searchaddbook = objAddressBookBO.GetAddresses(countryId, stateId, isActive);
                    ViewBag.FKStateId = new SelectList(objStateBO.GetStates(0, true), "PKStateId", "StateName");
                }
            }
            else if (col["btnReset"] == "Reset")
            {
                var searchaddbook = objAddressBookBO.GetAddresses();
                ViewBag.FKStateId = new SelectList(objStateBO.GetStates(0, true), "PKStateId", "StateName");
                return View("Index", searchaddbook);
            }
            return View();
        }
        //
        // GET: /Admin/AddressBook/Details/5
        public ActionResult Details(int id = 0)
        {
            AddressBook addressbook = objAddressBookBO.GetAddress(id);
            if (addressbook == null)
            {
                return HttpNotFound();
            }
            return View(addressbook);
        }
        //
        // GET: /Admin/AddressBook/Create
        public ActionResult Create()
        {
            ViewBag.FKStateId = new SelectList(objStateBO.GetStates(0, true), "PKStateId", "StateName");
            return View();
        }
        //
        // POST: /Admin/AddressBook/Create
        [HttpPost]
        public ActionResult Create(AddressBook addressbook)
        {
            if (ModelState.IsValid)
            {
                objAddressBookBO.InsertAddress(addressbook);
                return RedirectToAction("Index");
            }

            ViewBag.FKStateId = new SelectList(objStateBO.GetStates(0, true), "PKStateId", "StateName", addressbook.FKStateId);
            return View(addressbook);
        }
        //
        // GET: /Admin/AddressBook/Edit/5
        public ActionResult Edit(int id = 0)
        {
            AddressBook addressbook = objAddressBookBO.GetAddress(id);
            if (addressbook == null)
            {
                return HttpNotFound();
            }
            int selectedvalue = objStateBO.GetState(addressbook.FKStateId).FKCountryId;
            ViewBag.PKCountryId = new SelectList(objCountryBO.GetCountries(true), "PKCountryId", "CountryName", selectedvalue);
            ViewBag.FKStateId = new SelectList(objStateBO.GetStates(0, true), "PKStateId", "StateName", addressbook.FKStateId);
            return View(addressbook);
        }
        //
        // POST: /Admin/AddressBook/Edit/5
        [HttpPost]
        public ActionResult Edit(AddressBook addressbook)
        {
            if (ModelState.IsValid)
            {
                objAddressBookBO.UpdateAddress(addressbook);
                return RedirectToAction("Index");
            }
            int selectedvalue = objStateBO.GetState(addressbook.FKStateId).FKCountryId;
            ViewBag.PKCountryId = new SelectList(objCountryBO.GetCountries(true), "PKCountryId", "CountryName", selectedvalue);
            ViewBag.FKStateId = new SelectList(objStateBO.GetStates(0, true), "PKStateId", "StateName", addressbook.FKStateId);
            return View(addressbook);
        }
        //
        // GET: /Admin/AddressBook/Delete/5
        public ActionResult Delete(int id = 0)
        {
            AddressBook addressbook = objAddressBookBO.GetAddress(id);
            if (addressbook == null)
            {
                return HttpNotFound();
            }
            return View(addressbook);
        }
        //
        // POST: /Admin/AddressBook/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            objAddressBookBO.DeleteAddress(id);
            return RedirectToAction("Index");
        }
        public ActionResult GetStates(int id)
        {
            var lstStates = objStateBO.GetStates(id, true);
            return Json(lstStates, JsonRequestBehavior.AllowGet);
        }
    }
}