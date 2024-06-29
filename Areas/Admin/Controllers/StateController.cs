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
    public class StateController : Controller
    {
        //
        // GET: /Admin/State/
        StateBO objStateBO = new StateBO();
        CountryBO objCountryBO = new CountryBO();
        public ActionResult Index()
        {
            ViewBag.FKCountryId = new SelectList(objCountryBO.GetCountries(true), "PKCountryId", "CountryName");
            return View(objStateBO.GetStates());
        }
        [HttpPost]
        public ActionResult Index(FormCollection col)
        {
            int CountryId;
            if (col["btnSearch"] == "Search")
            {
                if (col["FKCountryId"] == "")
                    CountryId = 0;
                else
                    CountryId = Convert.ToInt32(col["FKCountryId"]);
                List<State> lstState = objStateBO.GetStates(CountryId);
                ViewBag.FKCountryId = new SelectList(objCountryBO.GetCountries(true), "PKCountryId", "CountryName");
                return View("Index", lstState);
            }
            else if (col["btnReset"] == "Reset")
            {
                List<State> lstState = objStateBO.GetStates();
                ViewBag.FKCountryId = new SelectList(objCountryBO.GetCountries(true), "PKCountryId", "CountryName");
                return View("Index", lstState);
            }
            return View();
        }
        //
        // GET: /Admin/State/Details/5
        public ActionResult Details(int id = 0)
        {
            State state = objStateBO.GetState(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }
        //
        // GET: /Admin/State/Create
        public ActionResult Create()
        {
            ViewBag.FKCountryId = new SelectList(objCountryBO.GetCountries(true), "PKCountryId", "CountryName");
            return View();
        }
        //
        // POST: /Admin/State/Create
        [HttpPost]
        public ActionResult Create(State state)
        {
            if (ModelState.IsValid)
            {
                objStateBO.InsertState(state);
                return RedirectToAction("Index");
            }
            ViewBag.FKCountryId = new SelectList(objCountryBO.GetCountries(true), "PKCountryId", "CountryName", state.FKCountryId);
            return View(state);
        }
        //
        // GET: /Admin/State/Edit/5
        public ActionResult Edit(int id = 0)
        {
            State state = objStateBO.GetState(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKCountryId = new SelectList(objCountryBO.GetCountries(true), "PKCountryId", "CountryName", state.FKCountryId);
            return View(state);
        }
        //
        // POST: /Admin/State/Edit/5
        [HttpPost]
        public ActionResult Edit(State state)
        {
            if (ModelState.IsValid)
            {
                objStateBO.UpdateState(state);
                return RedirectToAction("Index");
            }
            ViewBag.FKCountryId = new SelectList(objCountryBO.GetCountries(true), "PKCountryId", "CountryName", state.FKCountryId);
            return View(state);
        }
        //
        // GET: /Admin/State/Delete/5
        public ActionResult Delete(int id = 0)
        {
            State state = objStateBO.GetState(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }
        //
        // POST: /Admin/State/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            objStateBO.DeleteState(id);
            return RedirectToAction("Index");
        }
    }
}