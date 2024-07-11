using FPT.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.BusinessLogic
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<React> Reacts { get; set; } = new List<React> { };
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<CommentReply> CommentReply { get; set; } = new List<CommentReply> { };
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; } = DateTime.Now;
    }
}
