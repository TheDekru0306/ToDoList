using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class AdminUserListViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public List<ListViewModel> Lists { get; set; }
    }
}