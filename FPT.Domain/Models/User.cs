using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT.BusinessLogic
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; } = "https://i0.wp.com/sbcf.fr/wp-content/uploads/2018/03/sbcf-default-avatar.png?ssl=1";
        public UserRole UserRole { get; set; } = UserRole.GeneralUser;
    }
}
