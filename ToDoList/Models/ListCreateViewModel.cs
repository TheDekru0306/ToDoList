﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class ListCreateViewModel
    {
       
        public string Title { get; set; }

        
        public string Content { get; set; }
    }
}