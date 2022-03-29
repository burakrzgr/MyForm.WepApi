using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Burakrzgr.MyForm.Entity.Entities
{
    [Keyless]
    public partial class QuestionTemplateChoice
    {
        public int QuestionTemplateId { get; set; }
        public int ChoiceId { get; set; }
    }
}
