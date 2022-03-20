namespace Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate
{
    public class Form
    {

        public int Id { get; set; }
        public string? FormName { get; set; }
        public string? PersonellInfo { get; set; }
        public DateTime? DateofCreate { get; set; }
        public List<Question>? Questions { get; set; }

    }
}
