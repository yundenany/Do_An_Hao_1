using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Do_An_Hao_1.Models;
using System.Web.Mvc;
using DbModel = Do_An_Hao_1.Models.DbModel;
using static System.Net.WebRequestMethods;


namespace Do_An_Hao_1.Controllers
{
    public class booksController : Controller
    {
        private DbModel db = new DbModel();

        // GET: books
        public ActionResult Index()
        {
            return View(db.books.ToList());
        }

        // GET: books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "id_book,title,author,decription,images,public_date,category")] */book book)
        {

            if (ModelState.IsValid)
            {
                var file = Request.Files[0];
                string path = "";
                if (file != null && file.ContentLength > 0)
                {
                    path = file.FileName;
                    var path1 = Path.Combine(Server.MapPath("~/Content/ImageBooks/"), Path.GetFileName(file.FileName));
                    file.SaveAs(path1);
                }

                book.images = path;
                db.books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            /*ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", model.CategoryId);*/
            return View(book);

            /*if (ModelState.IsValid)
            {
                db.books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);*/
        }

        // GET: books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_book,title,author,decription,images,public_date,category")]book book)
        {
            if (ModelState.IsValid)
            {

                var file = Request.Files[0];
                string path = "";
                if (file != null && file.ContentLength > 0)
                {
                    path = file.FileName;
                    var path1 = Path.Combine(Server.MapPath("~/Content/ImageBooks/"), Path.GetFileName(file.FileName));
                    file.SaveAs(path1);
                }

                book.images = path;
                db.Entry(book).State = EntityState.Modified;
                /*db.books.Add(book);*/
                db.SaveChanges();
                return RedirectToAction("Index");

                /*  db.Entry(book).State = EntityState.Modified;
                  db.SaveChanges();
                  return RedirectToAction("Index");*/
            }
            return View(book);
        }

        // GET: books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = db.books.Find(id);
            db.books.Remove(book);
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
