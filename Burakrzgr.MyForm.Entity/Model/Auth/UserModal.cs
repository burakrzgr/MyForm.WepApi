using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Entity.Model.Auth
{
    public class UserModal
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string[] Roles { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public DateTime TokenExpiration { get; set; }
    }
}
