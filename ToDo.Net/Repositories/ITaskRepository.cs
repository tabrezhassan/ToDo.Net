using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDo.Net.DAL;
using ToDo.Net.Models;

namespace ToDo.Net.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<ToDoList> GetAll(int? page);
        ToDoList GetById(int id);
        IEnumerable<ToDoList> Completed(int? page);
        void Insert(ToDoList todolist);
        void Update(ToDoList todolist);
        void Delete (int id);

        ToDoList TaskCompleted(ToDoList todolist);
        void Save();


    }
}