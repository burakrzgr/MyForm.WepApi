using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.Interfaces
{
    public interface IQuestionTemplate
    {
        IList<QuestionTemplate> Get(int templateId);
    }
}
