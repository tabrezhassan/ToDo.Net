using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDo.Net.DAL;
using ToDo.Net.Models;
using PagedList;

namespace ToDo.Net.Controllers
{
    public class ToDoListsController : Controller
    {
        private ToDoContext db = new ToDoContext();

        // GET: ToDoLists

        [HttpGet]
        public ActionResult Index(int? page)
        {
            //var todolist = db.ToDoList.Find(Completed == true );
            var todolist = db.ToDoList.Where(n => (n.Completed) == false).ToList();

            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<ToDoList> list = null;
            list = todolist.ToPagedList(pageIndex, pageSize);

            return View(list);

           


        }

        public ActionResult Completed()
        {
            var todolist = db.ToDoList.Where(n => (n.Completed) == true).ToList();
            
            return View(todolist.ToList());
        }

        // GET: ToDoLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDoList.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            return View(toDoList);
        }

        // GET: ToDoLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Task,DueDate,TaskPriority")] ToDoList toDoList)
        {
            toDoList.Task = toDoList.Task.ToUpper();

            if (ModelState.IsValid)
            {
                db.ToDoList.Add(toDoList);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Task Saved Successfully";
                return RedirectToAction("Index");
            }

            return View(toDoList);
        }

        // GET: ToDoLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDoList.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            return View(toDoList);
        }

        // POST: ToDoLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Task,DueDate,TaskPriority")] ToDoList toDoList)
        {
            toDoList.Task = toDoList.Task.ToUpper();

            if (ModelState.IsValid)
            {
                db.Entry(toDoList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoList);
        }

        // GET: ToDoLists/Delete/5

        public ActionResult TaskCompleted(int id,ToDoList toDoList)
        {

            if (ModelState.IsValid)
            {
                var datecompleted = DateTime.Now.ToShortDateString();
                var todolist = db.ToDoList.Where(n => n.ID == id).SingleOrDefault();
                TimeSpan ts = Convert.ToDateTime(datecompleted) - todolist.DueDate;

                todolist.Completed = true;
                todolist.DateCompleted = Convert.ToDateTime(datecompleted);
                todolist.DaysToComplete = ts.Days;

                db.Entry(todolist).State = EntityState.Modified;
                TempData["SuccessMessage"] = "Task Completed Successfully";
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(toDoList);

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDoList.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            return View(toDoList);
        }

        // POST: ToDoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoList toDoList = db.ToDoList.Find(id);
            db.ToDoList.Remove(toDoList);
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
