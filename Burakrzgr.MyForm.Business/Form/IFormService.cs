using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Burakrzgr.MyForm.Entity.Model;
using FormModel = Burakrzgr.MyForm.Entity.Model.Form;

namespace Burakrzgr.MyForm.Business.Form
{
    public interface IFormService
    {
        public FormModel GetForm(int id);
    }
}
