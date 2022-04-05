using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Entity.Model.CompletedForm
{
    public class CompletedQuestion
    {
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
