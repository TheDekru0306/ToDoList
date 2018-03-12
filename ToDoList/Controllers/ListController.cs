using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ToDoList.Models;

namespace ToDoList.Controllers.List
{
    public class ListController : Controller
    {
        ApplicationDbContext Context = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(ListCreateViewModel list)
        {
            var listToAdd = new toDoList()
            {
                Title = list.Title,
                Content = list.Content,
                User = Context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name)
            };

            Context.Lists.Add(listToAdd);
            Context.SaveChanges();

            return Redirect("../List/ViewAll");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var list = Context.Lists
                .Where(x => x.Id == id)
                .Select(x => new ListDeleteViewModel
                {
                    Title = x.Title,
                    Content = x.Content,
                    Id = x.Id
                }
                ).FirstOrDefault();

            return View(list);
        }

        [HttpPost]
        public ActionResult Delete(ListDeleteViewModel model)
        {
            var list = Context.Lists.FirstOrDefault(x => x.Id == model.Id);

            Context.Lists.Remove(list);
            Context.SaveChanges();

            return Redirect("../ViewAll");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var list = Context.Lists
                .Where(x => x.Id == id)
                .Select(x => new ListEditViewModel
                {
                    Title = x.Title,
                    Content = x.Content,
                    Id = x.Id
                }
                ).FirstOrDefault();

            return View(list);
        }

        [HttpPost]
        public ActionResult Edit(ListEditViewModel Model)
        {
            var list = Context.Lists.FirstOrDefault(x => x.Id == Model.Id);

            list.Title = Model.Title;
            list.Content = Model.Content;
            
            Context.SaveChanges();


            return Redirect("../ViewAll");
        }

        public ActionResult ViewAll()
        {
            var lists = Context.Lists
                .Where(x => x.User.UserName == User.Identity.Name)
                .Select(x => new ListViewModel()
                {
                    Title = x.Title,
                    Content = x.Content,
                    Id = x.Id
                }
                )
                .ToList();

            return View(lists);
        }

        

        

    }
}