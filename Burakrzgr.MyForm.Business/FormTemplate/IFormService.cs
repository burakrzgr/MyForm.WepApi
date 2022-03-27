using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Burakrzgr.MyForm.Entity.Model;
using FormModal = Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate.Form;

namespace Burakrzgr.MyForm.Business.FormTemplate
{
    public interface IFormService
    {
        public FormModal GetForm(int id);
        public IList<FormModal> GetFormList();

    }
}
