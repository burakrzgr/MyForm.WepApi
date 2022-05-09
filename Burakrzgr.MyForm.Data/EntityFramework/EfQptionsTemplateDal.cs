using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model;
using Burakrzgr.MyForm.Entity.Model.FormTemplate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.EntityFramework
{
    public class EfOptionsTemplateDal : IOptionsTemplateDal
    {
        FormDbContext _factory;
        public EfOptionsTemplateDal(FormDbContext factory)
        {
            _factory = factory;
        }

        public IResult<int> AddOptions(string[] options)
        {
            try
            {
                var dbChoices = _factory.Choices;
                IList<Choice> choices = options.Where(x => !dbChoices.Any(y => y.ChoiceText == x)).Select(x => new Choice { ChoiceText = x }).ToList<Choice>();
                _factory.Choices.AddRange(choices);
                _factory.SaveChanges();
                return new SuccessResult<int>(choices.Count);
            }
            catch (Exception ex)
            {
                return new ErrorResult<int>(0, "Db Error");
            }
        }

        public IResult<int> InsertOptionsToQuestion(OptionAnswerMerge[] submitted)
        {
            var dbChoices = _factory.Choices;
            IList<SubmittedQuestionChoice> insertList = submitted.SelectMany(x => x.Options.Select(y => new { Id = x.QuestionId, option = y })).Join(dbChoices, x => x.option, y => y.ChoiceText, (x, y) => new SubmittedQuestionChoice { ChoiceId = y.Id, SubmitedQuestionId = x.Id }).ToList();
            _factory.SubmittedQuestionChoices.AddRange(insertList);
            _factory.SaveChanges();
            return new SuccessResult<int>(insertList.Count);
        }

        public IResult<int> InsertOptionToTemplate(OptionAnswerMerge[] templates)
        {
            var dbChoices = _factory.Choices;
            IList<QuestionTemplateChoice> choicestemplates = templates.SelectMany(x => x.Options.Select(y => new { Id = x.QuestionId, option = y })).Join(dbChoices, x => x.option, y => y.ChoiceText, (x, y) => new QuestionTemplateChoice { ChoiceId = y.Id, QuestionTemplateId = x.Id }).ToList();
            _factory.QuestionTemplateChoices.AddRange(choicestemplates);
            _factory.SaveChanges();
            return new SuccessResult<int>(choicestemplates.Count);
        }
    }
}
