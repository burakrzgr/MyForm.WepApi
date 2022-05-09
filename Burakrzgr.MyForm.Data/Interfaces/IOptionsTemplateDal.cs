using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Entity.Model.FormTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.Interfaces
{
    public interface IOptionsTemplateDal
    {
        public IResult<int> AddOptions(string[] options);
        public IResult<int> InsertOptionToTemplate(OptionAnswerMerge[] templates);
        public IResult<int> InsertOptionsToQuestion(OptionAnswerMerge[] submitted);
    }
}
