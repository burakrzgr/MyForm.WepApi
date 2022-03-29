using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model;
using Burakrzgr.MyForm.Entity.Model.FormTemplate;
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
            IList<int> qid = questionlist.Select(x => x.Id).ToList();
            IList<QuestionTemplateChoice> templateChoices = _factory.QuestionTemplateChoices.Where(x => x.QuestionTemplateId == templateId).ToList();
            var choices = _factory.Choices.Join(_factory.QuestionTemplateChoices.Where(t => qid.Contains(t.QuestionTemplateId)) , x => x.Id, y => y.ChoiceId, (x, y) => new { y.QuestionTemplateId, x.ChoiceText }).ToList();

            questionlist = questionlist.Select(x => new QuestionTemplate
            {
                Id = x.Id,
                TemplateId = x.TemplateId,
                QuestionText = x.QuestionText,
                QuestionType = x.QuestionType, 
                AnswerStr1 = x.AnswerStr1,
                AnswerStr2 = x.AnswerStr2,
                AnswerBool1 = x.AnswerBool1,
                AnswerBool2 = x.AnswerBool2,
                AnswerInt1 = x.AnswerInt1,
                StrArray = choices.Where(y => y.QuestionTemplateId == x.Id).Select(y => y.ChoiceText).ToArray()
            }).ToList();
            return questionlist;
        }

        public IResult<IList<QuestionTemplate>> Add(IList<QuestionTemplate>? questions)
        {
            try
            {
                if (questions is not null)
                {
                    _factory.QuestionTemplates.AddRange(questions);
                    _factory.SaveChanges();
                }
                else
                {
                    return new ErrorResult<IList<QuestionTemplate>>(new List<QuestionTemplate>(),"question template null value");
                }

                return new SuccessResult<IList<QuestionTemplate>>(questions);
            }
            catch (Exception ex) { 
                return new ErrorResult<IList<QuestionTemplate>>(new List<QuestionTemplate>(), "Db Error"); 
            }
            //return result.State == EntityState.Added ? new SuccessResult<FormTemplate>(result.Entity) : new ErrorResult<FormTemplate>(result.Entity, "Db Error");
        }

    }
}
