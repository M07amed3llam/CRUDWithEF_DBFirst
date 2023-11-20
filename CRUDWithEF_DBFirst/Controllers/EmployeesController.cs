using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDWithEF_DBFirst.Models;

namespace CRUDWithEF_DBFirst.Controllers
{
    public class EmployeesController : Controller
    {
        private CRUDWithEFEntities db = new CRUDWithEFEntities();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.EmployeeMasters.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeMaster employeeMaster = db.EmployeeMasters.Find(id);
            if (employeeMaster == null)
            {
                return HttpNotFound();
            }
            return View(employeeMaster);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmpCode,EmpName,Designation,Salary")] EmployeeMaster employeeMaster)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeMasters.Add(employeeMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeMaster);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeMaster employeeMaster = db.EmployeeMasters.Find(id);
            if (employeeMaster == null)
            {
                return HttpNotFound();
            }
            return View(employeeMaster);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmpCode,EmpName,Designation,Salary")] EmployeeMaster employeeMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeMaster);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeMaster employeeMaster = db.EmployeeMasters.Find(id);
            if (employeeMaster == null)
            {
                return HttpNotFound();
            }
            return View(employeeMaster);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeMaster employeeMaster = db.EmployeeMasters.Find(id);
            db.EmployeeMasters.Remove(employeeMaster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
