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
    public class EfOptionsTemplate : IOptionsTemplate
    {
        FormDbContext _factory;
        public EfOptionsTemplate(FormDbContext factory)
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

        public IResult<int> MergeOptions(OptionAnswerMerge[] templates)
        {
            var dbChoices = _factory.Choices;
            IList<QuestionTemplateChoice> choicestemplates = templates.SelectMany(x => x.Options.Select(y => new { Id = x.Question.Id, option = y })).Join(dbChoices, x => x.option, y => y.ChoiceText, (x, y) => new QuestionTemplateChoice { ChoiceId = y.Id, QuestionTemplateId = x.Id }).ToList<QuestionTemplateChoice>();
            _factory.QuestionTemplateChoices.AddRange(choicestemplates);
            _factory.SaveChanges();
            return new SuccessResult<int>(choicestemplates.Count);
        }
    }
}
