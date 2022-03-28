using Burakrzgr.MyForm.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.Interfaces
{
    public interface IOptionsTemplate
    {
        public IResult<int> AddOptions(string[] options);
        public IResult<int> MergeOptions(IQuestionTemplate[] templates);
    }
}
