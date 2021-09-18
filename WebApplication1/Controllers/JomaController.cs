using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class JomaController : Controller
    {
        private LibraryDB db = new LibraryDB();

        // GET: Joma
        public ActionResult Index()
        {
            var bookIssueReturns = db.BookIssueReturns.Where(x => x.ActualReturnDate == null).Include(b => b.Book).Include(b => b.Member);
            return View(bookIssueReturns.ToList());
        }

        // GET: Joma
        public ActionResult ReturnBooks()
        {
            var bookIssueReturns = db.BookIssueReturns.Where(x => x.ActualReturnDate != null).Include(b => b.Book).Include(b => b.Member);
            return View(bookIssueReturns.ToList());
        }

        // GET: Joma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssueReturn bookIssueReturn = db.BookIssueReturns.Find(id);
            if (bookIssueReturn == null)
            {
                return HttpNotFound();
            }
            return View(bookIssueReturn);
        }

        // GET: Joma/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Code");
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName");
            return View();
        }

        // POST: Joma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MemberId,BookId,IssueDate,ReturnDate,ActualReturnDate,OneDateFine,TotalFine")] BookIssueReturn bookIssueReturn)
        {
            if (ModelState.IsValid)
            {
                var oIssue = db.BookIssueReturns.Where(x => x.BookId == bookIssueReturn.BookId).FirstOrDefault();
                if (oIssue == null || (oIssue != null && oIssue.ActualReturnDate != null))
                {
                    db.BookIssueReturns.Add(bookIssueReturn);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Msg = "The book is issued already.";
                }
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "Code", bookIssueReturn.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", bookIssueReturn.MemberId);
            return View(bookIssueReturn);
        }

        // GET: Joma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssueReturn bookIssueReturn = db.BookIssueReturns.Find(id);
            if (bookIssueReturn == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Code", bookIssueReturn.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", bookIssueReturn.MemberId);
            return View(bookIssueReturn);
        }

        // POST: Joma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberId,BookId,IssueDate,ReturnDate,ActualReturnDate,OneDateFine,TotalFine")] BookIssueReturn bookIssueReturn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookIssueReturn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Code", bookIssueReturn.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", bookIssueReturn.MemberId);
            return View(bookIssueReturn);
        }

        // GET: Joma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssueReturn bookIssueReturn = db.BookIssueReturns.Find(id);
            if (bookIssueReturn == null)
            {
                return HttpNotFound();
            }
            return View(bookIssueReturn);
        }

        // POST: Joma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookIssueReturn bookIssueReturn = db.BookIssueReturns.Find(id);
            db.BookIssueReturns.Remove(bookIssueReturn);
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

        #region Return Book
        // GET: Joma/ReturnBook/5
        public ActionResult ReturnBook(int? id)
        { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssueReturn bookIssueReturn = db.BookIssueReturns.Find(id);
            if (bookIssueReturn == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Code", bookIssueReturn.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", bookIssueReturn.MemberId);
            return View(bookIssueReturn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnBook([Bind(Include = "Id,MemberId,BookId,IssueDate,ReturnDate,ActualReturnDate,OneDateFine,TotalFine")] BookIssueReturn bookIssueReturn)
        { 
            if (ModelState.IsValid)
            {
                db.Entry(bookIssueReturn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Code", bookIssueReturn.BookId);
            ViewBag.MemberId = new SelectList(db.Members, "MemberId", "MemberName", bookIssueReturn.MemberId);
            return View(bookIssueReturn);
        }
        #endregion

        // GET: Joma/ReturnBook
        public JsonResult GetFineForLate(DateTime returnDate, DateTime actualReturnDate, double oneDayFine)
        {
            double fines = 0.00;
            var lateDays = actualReturnDate.Date.Subtract(returnDate.Date).Days;
            if (lateDays > 0)
            {
                fines = lateDays * oneDayFine;
            }
            var results = new { totalFine = fines };

            return Json(results, JsonRequestBehavior.AllowGet);
        }

    }
}
