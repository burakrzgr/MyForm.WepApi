namespace Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate
{
    public class Form
    {

        public int Id { get; set; }
        public string? FormName { get; set; }
        public string? FormDesc { get; set; }
        public int? PersonalInfo { get; set; }
        public DateTime? DateofCreate { get; set; }
        public IList<Question>? Questions { get; set; }

    }
}
