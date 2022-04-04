using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.EntityFramework
{
    public class EfSubmittedQuestion : ISubmittedQuestion
    {
        FormDbContext _factory;
        public EfSubmittedQuestion(FormDbContext factory)
        {
            _factory = factory;
        }
        public IResult<IList<SubmittedQuestion>> Add(IList<SubmittedQuestion>? questions)
        {
            try
            {
                if (questions is not null)
                {
                    _factory.SubmittedQuestions.AddRange(questions);
                    _factory.SaveChanges();
                }
                else
                {
                    return new ErrorResult<IList<SubmittedQuestion>>(new List<SubmittedQuestion>(), "submitted question null value");
                }

                return new SuccessResult<IList<SubmittedQuestion>>(questions);
            }
            catch (Exception ex)
            {
                return new ErrorResult<IList<SubmittedQuestion>>(new List<SubmittedQuestion>(), "Db Error");
            }
        }
    }
}
