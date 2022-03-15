namespace Burakrzgr.MyForm.Entity.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string? QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }
        public string? ReplyValue { get; set; }
        public IList<Option>? Options { get; set; }


    }
}