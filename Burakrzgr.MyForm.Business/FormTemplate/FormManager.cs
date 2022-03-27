using Burakrzgr.MyForm.Business.QuestionManager;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Model;
using FormModel = Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate.Form;

namespace Burakrzgr.MyForm.Business.FormTemplate
{
    public class FormManager : IFormService
    {
        readonly IFormData _formData;
        readonly IQuestionTemplate _questionTemplate;
        readonly IFormTemplate _formTemplate;
        readonly QuestionConverter _questionManager;
        public FormManager(IFormData formData,IQuestionTemplate questionTemplate,IFormTemplate formTemplate, QuestionConverter questionManager)
        {
            _formData = formData;
            _questionTemplate = questionTemplate;
            _formTemplate = formTemplate;
            _questionManager = questionManager;
        }
        public FormModel GetForm(int id)
        {
            var form = _formTemplate.Get(id);
            if (form != null) {
                FormModel fm = new FormModel { Id = form.Id, FormName = form.FormName, FormDesc = form.FormDesc, DateofCreate = form.DateOfCreate, PersonalInfo = form.PersonalInfo };
                fm.Questions = _questionTemplate.Get(id).Select(x =>_questionManager.GetQuestion(x)).ToList();
                return fm;
            }
            else return new FormModel { Id = 9999, FormName = "error", FormDesc = "", DateofCreate = DateTime.Now, PersonalInfo = "error", Questions = new List<Question>() };
        }
        public IList<FormModel> GetFormList()
        {
            var form = _formTemplate.GetAll();
           
            return form.Select(x => new FormModel { Id = x.Id, FormName = x.FormName, FormDesc = x.FormDesc, DateofCreate = x.DateOfCreate, PersonalInfo = x.PersonalInfo }).ToList();
        }
    }
}
