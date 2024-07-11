using FPT.BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.BusinessLogic.Models
{
    public class React
    {
        public int Id { get; set; }
        public Emotion Emotion { get; set; }
        public int UserId { get; set; }
        public virtual User User {get; set;}
        public int? PostId { get; set; }
        public virtual Post? Post { get; set; }
        public int? CommentId { get; set; }
        public virtual Comment? Comment { get; set; }
    }
}
