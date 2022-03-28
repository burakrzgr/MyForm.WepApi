using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.EntityFramework
{
    public class EfOptionsTemplate : IOptionsTemplate
    {
        FormDbContext _factory;
        public EfOptionsTemplate(FormDbContext factory)
        {
            _factory = factory;
        }

        public IResult<int> AddOptions(string[] options)
        {
            throw new NotImplementedException();
        }

        public IResult<int> MergeOptions(IQuestionTemplate[] templates)
        {
            throw new NotImplementedException();
        }
    }
}
