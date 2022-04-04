using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Model.FilledForm;

namespace Burakrzgr.MyForm.Business.FilledForm
{
    public class FilledFormManager : IFilledFormService
    {
        readonly ISubmitedForm _submitedForm;
        public FilledFormManager(ISubmitedForm submitedForm)
        {
            _submitedForm = submitedForm;
        }
        public bool SaveForm(SubmitedForm filledForm)
        {
            _submitedForm.Add(filledForm);
            return true;
        }
    }
}
