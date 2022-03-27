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
    public class EfQuestionTemplate : IQuestionTemplate
    {
        FormDbContext _factory;
        public EfQuestionTemplate(FormDbContext factory)
        {
            _factory = factory;
        }

        public IList<QuestionTemplate> Get(int templateId)
        {
            IList<QuestionTemplate> questionlist = _factory.QuestionTemplates.Where(x => x.TemplateId == templateId).ToList();
            return questionlist;
        }

        public IResult<string> Add(IList<QuestionTemplate>? questions)
        {
            try
            {
                _factory.QuestionTemplates.AddRange(questions);
                _factory.SaveChanges();
                return new SuccessResult<string>("");
            }
            catch (Exception ex) { 
                return new ErrorResult<string>("Error", "Db Error"); 
            }
            //return result.State == EntityState.Added ? new SuccessResult<FormTemplate>(result.Entity) : new ErrorResult<FormTemplate>(result.Entity, "Db Error");
        }

    }
}
