using System;
using System.Collections.Generic;

namespace Burakrzgr.MyForm.Entity.Entities
{
    public partial class SubmittedQuestion
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string? Answer { get; set; }
    }
}
