using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Burakrzgr.MyForm.Business.QuestionManager;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model.FormTemplate;
using Burakrzgr.MyForm.Entity.Model.SubmittedForm;

namespace Burakrzgr.MyForm.Business.FilledForm
{
    public class FilledFormManager : IFilledFormService
    {
        readonly ISubmittedForm _submitedForm;
        readonly ISubmittedQuestion _submittedQuestion;
        readonly SubmittedQuestionConverter _converter;
        readonly IOptionsTemplate _optionsTemplate;
        
      //  readonly QuestionType[] NonAnswers = new QuestionType[] { QuestionType.Info};
      //  readonly int[] _choiceQuestions = new int[] { (int)QuestionType.RadioButton, (int)QuestionType.ComboBox, (int)QuestionType.Upload };
        public FilledFormManager(ISubmittedForm submitedForm, ISubmittedQuestion submittedQuestion, SubmittedQuestionConverter converter, IOptionsTemplate optionsTemplate)
        {
            _submitedForm = submitedForm;
            _submittedQuestion = submittedQuestion;
            _converter = converter;
            _optionsTemplate = optionsTemplate;
        }

        public bool SaveForm(SubmitedFormModel filledForm)
        {
            try
            {
                SubmittedForm submitForm = new SubmittedForm { Id = filledForm.Id ?? 0, ParticipantId = 1, PersonalInfoShared = filledForm.PerosnalInfoShared ?? false, TemplateId = filledForm.TemplateId};
                var form = _submitedForm.Add(submitForm);
                if (form.IsSuccess)
                {
                    int id = form.Data?.Id??0;
                    IList<SubmittedQuestion> questions = filledForm.Questions?.Where(x => x.QuestionType != QuestionType.Info).Select(x => _converter.GetSubmitted(x, id)).ToList()?? new List<SubmittedQuestion>();
                    _ = _submittedQuestion.Add(questions);
                    OptionAnswerMerge[]? list = questions.Where(x => x.Choices != null ?(x.Choices.Length > 0):false).Select(x => new OptionAnswerMerge { QuestionId = x.Id, Options = x.Choices ?? Array.Empty<string>() }).ToArray();
                    _optionsTemplate.InsertOptionsToQuestion(list);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
