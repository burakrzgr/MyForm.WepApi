using Burakrzgr.MyForm.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Entity.Model.FilledForm
{
    public class AnswerValue
    {
        public QuestionTemplate QuestionTemplate { get; set; }
        public string? TextValue { get; set; }

    }
}
