using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class EmailViewModel
    {

        [Required]
        public string To { get; set; }

        [Required]   
        [MinLength(3)]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }
    }
}