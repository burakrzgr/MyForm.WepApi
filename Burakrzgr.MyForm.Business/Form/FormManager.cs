using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormModel = Burakrzgr.MyForm.Entity.Model.Form;

namespace Burakrzgr.MyForm.Business.Form
{
    public class FormManager : IFormService
    {
        IFormData _formData;
        IQuestionData _questionData;
        public FormManager(IFormData formData,IQuestionData questionData)
        {
            _formData = formData;
            _questionData = questionData;
        }  

        public FormModel GetForm(int id)
        {
            var form = _formData.GetForm(id);
            form.Questions = _questionData.GetQuestionWithFormId(id);
            return form;
        }
    }
}
