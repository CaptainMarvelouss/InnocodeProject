using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.BusinessLogic
{
    public class UpdatePostStateDto
    {
        public int PostId { get; set; }
        public State State { get; set; }
    }
}
