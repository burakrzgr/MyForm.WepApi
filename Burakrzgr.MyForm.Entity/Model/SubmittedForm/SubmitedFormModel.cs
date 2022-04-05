using Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate;

namespace Burakrzgr.MyForm.Entity.Model.SubmittedForm
{
    public class SubmitedFormModel
    {
        public int? Id { get; set; } 
        public int TemplateId { get; set; }
        public string? ParticipantId { get; set; }
        public bool? PerosnalInfoShared { get; set; }
        public IList<SubmittedQuestionModel>? Questions { get; set; }
    }
}
