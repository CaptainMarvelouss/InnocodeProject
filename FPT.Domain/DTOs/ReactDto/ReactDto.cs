using FPT.BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.BusinessLogic
{
    public class ReactDto
    {
        public Emotion Emotion { get; set; }

        public int UserId { get; set; }

        public int? PostID { get; set; }

        public int? CommentId { get; set; }

        public int? CommentReplyId { get; set; }
    }
}
