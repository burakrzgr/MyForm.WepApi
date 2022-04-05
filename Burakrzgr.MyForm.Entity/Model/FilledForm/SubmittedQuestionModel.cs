using Burakrzgr.MyForm.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Entity.Model.FilledForm
{
    public class SubmittedQuestionModel
    {
        public int? Id { get; set; }
        public int TemplateId { get; set; }
        public QuestionType QuestionType { get; set; }
        public dynamic? AnsweredValue { get; set; }

    }
}
