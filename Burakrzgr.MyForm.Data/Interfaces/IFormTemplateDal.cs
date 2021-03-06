using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.Interfaces
{
    public interface IFormTemplateDal
    {
        FormTemplate? Get(int id);
        IList<FormTemplate> GetAll();
        FormTemplate? Delete(int id);
        IResult<FormTemplate> Add(FormTemplate form);
    }
}
