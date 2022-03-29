using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burakrzgr.MyForm.Entity.Entities
{
    public partial class QuestionTemplate
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string QuestionText { get; set; } = null!;
        public int QuestionType { get; set; }
        public string? AnswerStr1 { get; set; }
        public string? AnswerStr2 { get; set; }
        public bool? AnswerBool1 { get; set; }
        public bool? AnswerBool2 { get; set; }
        public int? AnswerInt1 { get; set; }
        [NotMapped]
        public string[]? StrArray { get; set; }
    }
}
