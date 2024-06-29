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
    public class UserDetailController : Controller
    {
        //
        // GET: /Admin/UserDetail/
        UserBO objUserBO = new UserBO();
        public ActionResult Index()
        {
            return View(objUserBO.GetUsers());
        }
        //
        // GET: /Admin/UserDetail/Details/5
        public ActionResult Details(int id = 0)
        {
            UserDetail userdetail = objUserBO.GetUser(id);
            if (userdetail == null)
            {
                return HttpNotFound();
            }
            return View(userdetail);
        }
        //
        // GET: /Admin/UserDetail/Create
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Admin/UserDetail/Create
        [HttpPost]
        public ActionResult Create(UserDetail userdetail)
        {
            if (ModelState.IsValid)
            {
                objUserBO.InsertUser(userdetail);
                return RedirectToAction("Index");
            }

            return View(userdetail);
        }
        //
        // GET: /Admin/UserDetail/Edit/5
        public ActionResult Edit(int id = 0)
        {
            UserDetail userdetail = objUserBO.GetUser(id);
            if (userdetail == null)
            {
                return HttpNotFound();
            }
            return View(userdetail);
        }
        //
        // POST: /Admin/UserDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(UserDetail userdetail)
        {
            if (ModelState.IsValid)
            {
                objUserBO.UpdateUser(userdetail);
                return RedirectToAction("Index");
            }
            return View(userdetail);
        }
        //
        // GET: /Admin/UserDetail/Delete/5
        public ActionResult Delete(int id = 0)
        {
            UserDetail userdetail = objUserBO.GetUser(id);
            if (userdetail == null)
            {
                return HttpNotFound();
            }
            return View(userdetail);
        }
        //
        // POST: /Admin/UserDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            objUserBO.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}