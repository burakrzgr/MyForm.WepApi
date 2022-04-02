using Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate;

namespace Burakrzgr.MyForm.Entity.Model.FilledForm
{
    public class FilledForm
    {
        public Form FormTemplate { get; set; }
        public string User { get; set; }
        public DateTime FillDate { get; set; }
        public bool IsComplete { get; set; }
        public bool PersonelInfoShared { get; set; }
        public IList<AnswerValues> answers { get; set; }
    }
}
