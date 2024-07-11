using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.BusinessLogic
{
    public class UpdatePostDto
    {
        public int PostId { get; set; }
        public Category Category { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; }
        public string Title { get; set; }
    }
}
