using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model.FilledForm;

namespace Burakrzgr.MyForm.Business.FilledForm
{
    public class FilledFormManager : IFilledFormService
    {
        readonly ISubmittedForm _submitedForm;
        public FilledFormManager(ISubmittedForm submitedForm)
        {
            _submitedForm = submitedForm;
        }
        public bool SaveForm(SubmitedFormModel filledForm)
        {
            try
            {
                SubmittedForm submitForm = new SubmittedForm { Id = filledForm.Id ?? 0, ParticipantId = 1, PerosnalInfoShared = filledForm.PerosnalInfoShared ?? false, TemplateId = filledForm.TemplateId };
                _submitedForm.Add(submitForm);
                
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
