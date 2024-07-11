using FPT.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.BusinessLogic
{
    public class CommentReply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual List<React> Reacts { get; set; } = new List<React> { };
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; } = DateTime.Now;
    }
}
