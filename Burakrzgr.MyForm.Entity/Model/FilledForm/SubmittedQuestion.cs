using Burakrzgr.MyForm.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Entity.Model.FilledForm
{
    public class SubmittedQuestion
    {
        public int? Id { get; set; }
        public int TemplateId { get; set; }
        public dynamic? AnsweredValue { get; set; }

    }
}
