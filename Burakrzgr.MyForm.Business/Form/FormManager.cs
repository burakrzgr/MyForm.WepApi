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
        public FormManager(IFormData formData)
        {
            _formData = formData;
        }  

        public FormModel GetForm(int id)
        {
            return _formData.GetForm(id);
        }
    }
}
