﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HCLProj;

namespace HCLProj.Controllers
{
    public class CarsController : Controller
    {
        private HCL2Entities db = new HCL2Entities();

        // GET: Cars
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,make,model_name,model_trim,model_year,body_style,engine_position,engine_cc,engine_num_cyl,engine_type,engine_valves_per_cyl,engine_power_ps,engine_power_rpm,engine_torque_nm,engine_torque_rpm,engine_bore_mm,engine_stroke_mm,engine_compression,engine_fuel,top_speed_kph,zero_to_100_kph,drive_type,transmission_type,seats,doors,weight_kg,length_mm,width_mm,height_mm,wheelbase,lkm_hwy,lkm_mixed,lkm_city,fuel_capacity_l,sold_in_us,co2,make_display")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,make,model_name,model_trim,model_year,body_style,engine_position,engine_cc,engine_num_cyl,engine_type,engine_valves_per_cyl,engine_power_ps,engine_power_rpm,engine_torque_nm,engine_torque_rpm,engine_bore_mm,engine_stroke_mm,engine_compression,engine_fuel,top_speed_kph,zero_to_100_kph,drive_type,transmission_type,seats,doors,weight_kg,length_mm,width_mm,height_mm,wheelbase,lkm_hwy,lkm_mixed,lkm_city,fuel_capacity_l,sold_in_us,co2,make_display")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
