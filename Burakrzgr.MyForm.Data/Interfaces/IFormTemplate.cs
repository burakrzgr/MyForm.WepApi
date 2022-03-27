using Burakrzgr.MyForm.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.Interfaces
{
    public interface IFormTemplate
    {
        FormTemplate Get(int id);
        IList<FormTemplate> GetAll();
    }
}
