using Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate;

namespace Burakrzgr.MyForm.Entity.Model.FilledForm
{
    public class SubmitedForm
    {
        public int? Id { get; set; } 
        public int TemplateId { get; set; }
        public string? ParticipantId { get; set; }
        public bool? PerosnalInfoShared { get; set; }
        public IList<SubmittedQuestion>? Questions { get; set; }
    }
}
