using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoList5As.Models;

namespace ToDoList5As.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
           : base(options)
        {
        }

        public DbSet<TodoList> ToDoList { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
