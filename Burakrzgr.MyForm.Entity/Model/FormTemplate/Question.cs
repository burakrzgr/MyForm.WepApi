using Burakrzgr.MyForm.Entity.Model.FormTemplate;
using Burakrzgr.MyForm.Entity.Model.AnswerTemplate;

namespace Burakrzgr.MyForm.Entity.Model
{
    public class Question
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string? QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }
        public dynamic? AnswerArea { get; set; }
    }
}