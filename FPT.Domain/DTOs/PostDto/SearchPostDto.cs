using FPT.BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.BusinessLogic
{
    public class SearchPostDto
    {
        public string searchString { get; set; } = "";
        public Category Category { get; set; } = Category.All;
        public SortEnum SortEnum { get; set; } = SortEnum.TimeDescending;
        public State State { get; set; } = State.Pending;
    }
}
