using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDo.Net.DAL;
using System.Data.Entity;
using ToDo.Net.Models;
using PagedList;

namespace ToDo.Net.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoContext _context;

        public TaskRepository()
        {
            _context = new ToDoContext();
        }

        public TaskRepository(ToDoContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDoList> GetAll(int? page)
        {
            //return _context.ToDoList.ToList();

            var todolist = _context.ToDoList.Where(n => (n.Completed) == false).ToList();

            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<ToDoList> list = null;
            list = todolist.ToPagedList(pageIndex, pageSize);

            return (list);
        }

        public IEnumerable<ToDoList> Completed(int? page)
        {
            var todolist = _context.ToDoList.Where(n => (n.Completed) == true).ToList();

            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<ToDoList> list = null;
            list = todolist.ToPagedList(pageIndex, pageSize);

            return (list);
        }
        public ToDoList GetById(int id)
        {
            return _context.ToDoList.Find(id);
        }

        public void Insert(ToDoList todolist)
        {
            todolist.Task = todolist.Task.ToUpper();

            _context.ToDoList.Add(todolist);

        }

        public void Update(ToDoList todolist)
        {
            todolist.Task = todolist.Task.ToUpper();

            _context.Entry(todolist).State = EntityState.Modified;

        }

        public ToDoList TaskCompleted(ToDoList todolist)
        {
            var datecompleted = DateTime.Now.ToShortDateString();
            TimeSpan ts = Convert.ToDateTime(datecompleted) - todolist.DueDate;

            todolist.Completed = true;
            todolist.DateCompleted = Convert.ToDateTime(datecompleted);
            todolist.DaysToComplete = ts.Days;

            _context.Entry(todolist).State = EntityState.Modified;
            Save();
            return (todolist);
        }
        public void Delete(int id)
        {
            ToDoList todolist = _context.ToDoList.Find(id);
            _context.ToDoList.Remove(todolist);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ToDoList TaskCompleted(int id)
        {
            throw new NotImplementedException();
        }
    }

}