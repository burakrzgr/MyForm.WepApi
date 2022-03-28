using Burakrzgr.MyForm.Entity.Model;

namespace Burakrzgr.MyForm.Entity.Model.AnswerTemplate
{
    public class OptionsAnswerArea : IAnswerArea
    {
        public string[]? Options { get; set; }
        public bool? Multi { get; set; }
    }
}