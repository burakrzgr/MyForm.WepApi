using Burakrzgr.MyForm.Entity.Model;

namespace Burakrzgr.MyForm.Entity.Model.AnswerTemplate
{
    public class DateTimeAnswerArea : IAnswerArea
    {
        public bool? CheckDate { get; set; }
        public bool? CheckTime { get; set; }
    }
}