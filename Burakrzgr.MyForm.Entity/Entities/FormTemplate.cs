using System;
using System.Collections.Generic;

namespace Burakrzgr.MyForm.Entity.Entities
{
    public partial class FormTemplate
    {
        public int Id { get; set; }
        public string FormName { get; set; } = null!;
        public string FormDesc { get; set; } = null!;
        public string PersonalInfo { get; set; } = null!;
        public DateTime DateOfCreate { get; set; }
        public int CreatorId { get; set; }
    }
}
