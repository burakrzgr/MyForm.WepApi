using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilledFormModel = Burakrzgr.MyForm.Entity.Model.SubmittedForm.SubmitedFormModel;


namespace Burakrzgr.MyForm.Business.FilledForm
{
    public interface IFilledFormService
    {
        public bool SaveForm(FilledFormModel filledForm);
        public FilledFormModel GetForm(int id);
    }
}
