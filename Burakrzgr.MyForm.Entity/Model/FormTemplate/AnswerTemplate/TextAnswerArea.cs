using Burakrzgr.MyForm.Entity.Model;

namespace Burakrzgr.MyForm.Entity.Model.AnswerTemplate
{
    public class TextAnswerArea : IAnswerArea
    {
        public string? DefaultText { get; set; }
        public int? TextHeight { get; set; }
    }
}