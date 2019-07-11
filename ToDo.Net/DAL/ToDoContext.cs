using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToDo.Net.Models;

namespace ToDo.Net.DAL
{
    public class ToDoContext : DbContext
    {
        public ToDoContext() : base("DefaultConnection")
        {
        }

        public DbSet<ToDoList> ToDoList { get; set; }
    }

}