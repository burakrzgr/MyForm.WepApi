﻿using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Entity.Model.FilledForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.Interfaces
{
    public interface ISubmitedForm
    {
        IResult<SubmitedForm> Add(SubmitedForm form);
    }
}
