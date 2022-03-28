using Burakrzgr.MyForm.Entity.Model;

namespace Burakrzgr.MyForm.Entity.Model.AnswerTemplate
{
    public class CheckAnswerArea : IAnswerArea
    {
        public bool? DefaultChecked { get; set; }
        public string? CheckText { get; set; }
        public string? Description { get; set; }
    }
}