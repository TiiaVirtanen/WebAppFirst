﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppFirst.Models;

namespace WebAppFirst.Controllers
{
    public class ShippersController : Controller
    {
        // GET: Shippers
        northwindEntities db = new northwindEntities();
        public ActionResult Index()
        {
            //List<Shippers> model = db.Shippers.ToList();
            //return View(model);
            var shippers = db.Shippers.Include(s => s.Region);
            return View(shippers.ToList());
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Shippers shippers = db.Shippers.Find(id);
            if (shippers == null) return HttpNotFound();
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription",shippers.RegionID);
            return View(shippers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "ShipperID,CompanyName,Phone,RegionID")] Shippers shippers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippers).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", shippers.RegionID);
                return RedirectToAction("Index");
            }
            return View(shippers);
        }

        public ActionResult Create()
        {
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "ShipperID,CompanyName,Phone,RegionID")] Shippers shipper)
        {
            if (ModelState.IsValid)
            {
                db.Shippers.Add(shipper);
                db.SaveChanges();
                ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription");
                return RedirectToAction("Index");
            }
            return View(shipper);

        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Shippers shippers = db.Shippers.Find(id);
            if (shippers == null) return HttpNotFound();
            return View(shippers);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Shippers shippers = db.Shippers.Find(id);
            db.Shippers.Remove(shippers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
