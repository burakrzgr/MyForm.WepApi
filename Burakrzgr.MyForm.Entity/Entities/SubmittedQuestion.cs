using System;
using System.Collections.Generic;

namespace Burakrzgr.MyForm.Entity.Entities
{
    public partial class SubmittedQuestion
    {
        public int Id { get; set; }
        public int QuestionTemplateId { get; set; }
        public int SubmittedFormId { get; set; }
        public string? Answer { get; set; }
    }
}
