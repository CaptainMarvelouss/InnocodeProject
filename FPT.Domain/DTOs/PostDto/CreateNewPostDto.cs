using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.BusinessLogic
{
    public class CreateNewPostDto
    {
        public int UserId { get; set; }
        public Category Category { get; set; }
        public string Content { get; set; }
        public string? Image {  get; set; }
        public string Title { get; set; }
        public State state { get; set; }
        // public 
    }
}
