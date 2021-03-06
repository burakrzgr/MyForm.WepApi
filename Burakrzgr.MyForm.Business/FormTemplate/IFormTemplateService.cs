using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Entity.Model;
using FormModal = Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate.Form;

namespace Burakrzgr.MyForm.Business.FormTemplate
{
    public interface IFormTemplateService
    {
        public FormModal GetForm(int id);
        public IList<FormModal> GetFormList();
        IResult<FormModal> PutForm(FormModal form);
        IResult<FormModal> DeleteForm(int id);
    }
}
