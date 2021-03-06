using System;
using System.Collections.Generic;

namespace Burakrzgr.MyForm.Entity.Entities
{
    public partial class FormTemplate
    {
        public int Id { get; set; }
        public string FormName { get; set; } = null!;
        public string FormDesc { get; set; } = null!;
        public int PersonalInfo { get; set; }
        public DateTime DateOfCreate { get; set; }
        public int CreatorId { get; set; }
        public bool Deleted { get; set; }
    }
}
