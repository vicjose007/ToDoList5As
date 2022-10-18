using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList5As.Context;
using ToDoList5As.Models;

namespace ToDoList5As.Controllers
{
    public class UserController : Controller
    {
        private readonly ToDoContext context;

        public UserController(ToDoContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult> Index()
        {
            IQueryable<User> items = from i in context.Users orderby i.Id select i;

            List<User> todoList = await items.ToListAsync();

            return View(todoList);

        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been added!";

                return RedirectToAction("Index");
            }

            return View(item);

        }

        public async Task<ActionResult> Edit(int id)
        {
            User item = await context.Users.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been updated!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        public async Task<ActionResult> Delete(int id)
        {
            User item = await context.Users.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
                context.Users.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted!";
            }

            return RedirectToAction("Index");
        }
    }
}
