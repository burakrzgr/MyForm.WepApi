using Burakrzgr.MyForm.Data.Interfaces;
using FormModel = Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate.Form;

namespace Burakrzgr.MyForm.Business.FormTemplate
{
    public class FormManager : IFormService
    {
        readonly IFormData _formData;
        readonly IQuestionData _questionData;
        readonly IFormTemplate _formTemplate;
        public FormManager(IFormData formData,IQuestionData questionData,IFormTemplate formTemplate)
        {
            _formData = formData;
            _questionData = questionData;
            _formTemplate = formTemplate;
        }  

        public FormModel GetForm(int id)
        {
            var form = _formData.GetForm(id);
            form.Questions = _questionData.GetQuestionWithFormId(id);
            return form;
        }

        public IList<FormModel> GetFormList()
        {
            var form = _formData.GetFormList();
            foreach (var item in form)
            {
                item.Questions = _questionData.GetQuestionWithFormId(item.Id);
            }
           
            return form;
        }
        public Entity.Entities.FormTemplate GetFormTemplate(int id)
        {
            //var form = _formData.GetForm(id);
            //form.Questions = _questionData.GetQuestionWithFormId(id);
            //return form;
            return _formTemplate.Get(id);
        }
    }
}
