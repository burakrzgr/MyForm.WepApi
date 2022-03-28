using Burakrzgr.MyForm.Entity.Model;

namespace Burakrzgr.MyForm.Entity.Model.AnswerTemplate
{
    public class InfoArea : IAnswerArea
    {
        public string? Variant { get; set; }
        public bool? Dismissive { get; set; }
    }
}