﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.BusinessLogic
{
    public class SignUpDto
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String ConfirmPassword { get; set; }
        public String Email { get; set; }
        public String avatar { get; set; }
        public String DisplayName { get; set; }
    }
}
