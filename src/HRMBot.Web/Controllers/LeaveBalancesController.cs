using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMBot.Models;
using HRMBot.Repository;

namespace HRMBot.Web.Controllers
{
    public class LeaveBalancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LeaveBalances
        public ActionResult Index()
        {
            var leaveBalances = db.LeaveBalances.Include(l => l.Employee);
            return View(leaveBalances.ToList());
        }

        // GET: LeaveBalances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveBalance leaveBalance = db.LeaveBalances.Find(id);
            if (leaveBalance == null)
            {
                return HttpNotFound();
            }
            return View(leaveBalance);
        }

        // GET: LeaveBalances/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName");
            return View();
        }

        // POST: LeaveBalances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TotalCasualLeave,TotalSickLeave,TotalAnnualLeave,AvailedCasualLeave,AvailedSickLeave,AvailedAnnualLeave,EmployeeId")] LeaveBalance leaveBalance)
        {
            if (ModelState.IsValid)
            {
                db.LeaveBalances.Add(leaveBalance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", leaveBalance.EmployeeId);
            return View(leaveBalance);
        }

        // GET: LeaveBalances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveBalance leaveBalance = db.LeaveBalances.Find(id);
            if (leaveBalance == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", leaveBalance.EmployeeId);
            return View(leaveBalance);
        }

        // POST: LeaveBalances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TotalCasualLeave,TotalSickLeave,TotalAnnualLeave,AvailedCasualLeave,AvailedSickLeave,AvailedAnnualLeave,EmployeeId")] LeaveBalance leaveBalance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveBalance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "FullName", leaveBalance.EmployeeId);
            return View(leaveBalance);
        }

        // GET: LeaveBalances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveBalance leaveBalance = db.LeaveBalances.Find(id);
            if (leaveBalance == null)
            {
                return HttpNotFound();
            }
            return View(leaveBalance);
        }

        // POST: LeaveBalances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveBalance leaveBalance = db.LeaveBalances.Find(id);
            db.LeaveBalances.Remove(leaveBalance);
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
