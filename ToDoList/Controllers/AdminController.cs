using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Users = "Denny Krumov")]
        public ActionResult ViewAllUsers()
        {
            var Users = db.Users.Select(x => new AdminViewModel {
                    Email = x.Email,
                    UserName = x.UserName,
                    Id = x.Id
            }).OrderBy(x => x.Email).ToList();

            return View(Users);
        }

        [HttpGet]
        [Authorize(Users = "Denny Krumov")]
        public ActionResult DeleteUser(string Id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == Id);

            var lists = user.Lists.ToList();

            foreach (var list in lists)
            {
                db.Lists.Remove(list);
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("ViewAllUsers", "Admin");
        }

        [HttpGet]
        [Authorize(Users = "Denny Krumov")]
        public ActionResult UserLists(string Id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == Id);
            var Lists = new AdminUserListViewModel {
                Lists = user.Lists.Select(x => new ListViewModel
                {
                    Content = x.Content,
                    Title = x.Title,
                    Id = x.Id
                }).ToList(),

                UserName = user.UserName,
                Email = user.Email

            };

            return View(Lists);
        }
    }
}