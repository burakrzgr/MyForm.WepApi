using Burakrzgr.MyForm.Entity.Model;

namespace Burakrzgr.MyForm.Entity.Model.Questions
{
    public class TextQuestion : Question
    {
        public string? DefaultText { get; set; }
        public int? TextHeight { get; set; }
    }
}