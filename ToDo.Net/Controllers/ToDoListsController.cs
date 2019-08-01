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
using ToDo.Net.Repositories;

namespace ToDo.Net.Controllers
{
    public class ToDoListsController : Controller
    {

        private ITaskRepository _taskRepository;

        public ToDoListsController()
        {
            _taskRepository = new TaskRepository(new ToDoContext());
        }

        public ToDoListsController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: ToDoLists

        [HttpGet]
        public ActionResult Index(int? page)
        {
         
            var list = _taskRepository.GetAll(page);
            return View(list);

        }

        public ActionResult Completed(int? page)
        {
            var list = _taskRepository.Completed(page);
            return View(list);
        }

        // GET: ToDoLists/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ToDoList toDoList = db.ToDoList.Find(id);
        //    if (toDoList == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(toDoList);
        //}

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
        public ActionResult Create(ToDoList todolist) //([Bind(Include = "ID,Task,DueDate,TaskPriority")] ToDoList toDoList)
        {
            

            if (ModelState.IsValid)
            {
                _taskRepository.Insert(todolist);
                _taskRepository.Save();
                TempData["SuccessMessage"] = "Task Saved Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: ToDoLists/Edit/5
        public ActionResult Edit(int id)
        {
          
            ToDoList todolist = _taskRepository.GetById(id);

            return View(todolist);
        }

        // POST: ToDoLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToDoList todolist) //([Bind(Include = "ID,Task,DueDate,TaskPriority")] ToDoList toDoList)
        {
            
            if (ModelState.IsValid)
            {
                _taskRepository.Update(todolist);
                _taskRepository.Save();
                return RedirectToAction("Index");
            }
            return View(todolist);
        }

        // GET: ToDoLists/Delete/5
        public ActionResult TaskCompleted(int id)
        {
            ToDoList todolist = _taskRepository.GetById(id);
            _taskRepository.TaskCompleted(todolist);
            return View();
        }

        [HttpPost]
        public ActionResult TaskCompleted(ToDoList todolist)
        {

            if (ModelState.IsValid)
            {
                _taskRepository.TaskCompleted(todolist);
                TempData["SuccessMessage"] = "Task Completed Successfully";

                return RedirectToAction("Index");
            }
            return View(todolist);

        }
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ToDoList toDoList = db.ToDoList.Find(id);
        //    if (toDoList == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(toDoList);
        //}

        //// POST: ToDoLists/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ToDoList toDoList = db.ToDoList.Find(id);
        //    db.ToDoList.Remove(toDoList);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
