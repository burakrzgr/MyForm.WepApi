using Burakrzgr.MyForm.Entity.Model.CompletedForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Business.Completed
{
    public interface ICompletedFormService
    {
        public CompletedFormModel GetForm(int id);
    }
}
