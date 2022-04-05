using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model.SubmittedForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.Interfaces
{
    public interface ISubmittedForm
    {
        IResult<SubmittedForm> Add(SubmittedForm form);
    }
}
