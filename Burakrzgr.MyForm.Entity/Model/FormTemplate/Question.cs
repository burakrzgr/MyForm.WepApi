using Burakrzgr.MyForm.Entity.Model.FormTemplate;

namespace Burakrzgr.MyForm.Entity.Model
{
    public class Question
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string? QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }
      /*  public string? AnswerStr1 { get; set; }
        public string? AnswerStr2 { get; set; }
        public bool? AnswerBool1 { get; set; }
        public bool? AnswerBool2 { get; set; }
        public int? AnswerInt1 { get; set; }*/
    }
}