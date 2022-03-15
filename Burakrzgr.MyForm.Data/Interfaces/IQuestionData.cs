using Burakrzgr.MyForm.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.Interfaces
{
    public interface IQuestionData
    {
        Question GetQuestion(int id);
        List<Question>? GetQuestionWithFormId(int formId);
    }
}
