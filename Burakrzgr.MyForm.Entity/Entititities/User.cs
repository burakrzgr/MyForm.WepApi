using System;
using System.Collections.Generic;

namespace Burakrzgr.MyForm.WepApi
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
    }
}
