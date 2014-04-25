using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRouting.Models;

namespace MvcRouting.Controllers
{
    public class RestaurantReviewController : Controller
    {
        private MvcRoutingDBContext db = new MvcRoutingDBContext();

        //
        // GET: /RestaurantReview/

        public ActionResult Index([Bind(Prefix = "id")]int restaurantId)
        {
            var restaurant = db.Restaurants.Find(restaurantId);
            if (restaurant != null)
            {
                return View(restaurant);    
            }
            return HttpNotFound();

        }

        
        // GET: /RestaurantReview/Details/5

        public ActionResult Details(int id = 0)
        {
            RestaurantReview restaurantreview = db.Reviews.Find(id);
            if (restaurantreview == null)
            {
                return HttpNotFound();
            }
            return View(restaurantreview);
        }

        
        //
        //
        // GET: /RestaurantReview/Create

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        //
        // POST: /RestaurantReview/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantReview restaurantreview)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(restaurantreview);
                db.SaveChanges();
                return RedirectToAction("Index", new {id = restaurantreview.RestaurantId});
            }

            return View(restaurantreview);
        }

        //
        // GET: /RestaurantReview/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RestaurantReview restaurantreview = db.Reviews.Find(id);
            if (restaurantreview == null)
            {
                return HttpNotFound();
            }
            return View(restaurantreview);
        }

        //
        // POST: /RestaurantReview/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "ReviewerName")]RestaurantReview restaurantreview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantreview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = restaurantreview.RestaurantId });
            }
            return View(restaurantreview);
        }

        //
        // GET: /RestaurantReview/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RestaurantReview restaurantreview = db.Reviews.Find(id);
            if (restaurantreview == null)
            {
                return HttpNotFound();
            }
            return View(restaurantreview);
        }

        //
        // POST: /RestaurantReview/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantReview restaurantreview = db.Reviews.Find(id);
            db.Reviews.Remove(restaurantreview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}