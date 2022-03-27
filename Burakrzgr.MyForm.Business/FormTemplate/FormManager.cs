using Burakrzgr.MyForm.Business.QuestionManager;
using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Model;
using FormTemplateEntity = Burakrzgr.MyForm.Entity.Entities.FormTemplate;
using FormModal = Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate.Form;

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
        public FormModal GetForm(int id)
        {
            var form = _formTemplate.Get(id);
            if (form != null) {
                FormModal fm = new FormModal { Id = form.Id, FormName = form.FormName, FormDesc = form.FormDesc, DateofCreate = form.DateOfCreate, PersonalInfo = form.PersonalInfo };
                fm.Questions = _questionTemplate.Get(id).Select(x =>_questionManager.GetQuestion(x)).ToList();
                return fm;
            }
            else return new FormModal { Id = 9999, FormName = "error", FormDesc = "", DateofCreate = DateTime.Now, PersonalInfo = 0, Questions = new List<Question>() };
        }
        public IList<FormModal> GetFormList()
        {
            var form = _formTemplate.GetAll();
           
            return form.Select(x => new FormModal { Id = x.Id, FormName = x.FormName, FormDesc = x.FormDesc, DateofCreate = x.DateOfCreate, PersonalInfo = x.PersonalInfo }).ToList();
        }

        public IResult<FormModal> PutForm(FormModal form)
        {
            IResult<FormTemplateEntity>? result = _formTemplate.Add(new FormTemplateEntity() { Id = form.Id, FormName = form.FormName ?? "", FormDesc = form.FormDesc, DateOfCreate = form.DateofCreate ?? DateTime.Now, PersonalInfo = form.PersonalInfo ?? 0 });
            form.Id = result.Data is null ? 0 : result.Data.Id;
            return result.IsSuccess ? new SuccessResult<FormModal>(form) : new ErrorResult<FormModal>(form, result.Message);
        }
    }
}
