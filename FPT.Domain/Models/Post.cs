﻿using FPT.BusinessLogic;
using FPT.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.BusinessLogic
{
    public class Post
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public virtual User User {get; set; }
        
        public string? Image { get; set; }

        public virtual List<React> Reacts { get; set; } = new List<React>();
        public State State { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime date { get; set; } = DateTime.Now;
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
