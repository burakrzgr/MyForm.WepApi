using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Burakrzgr.MyForm.Business.QuestionManager;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model.SubmittedForm;

namespace Burakrzgr.MyForm.Business.FilledForm
{
    public class FilledFormManager : IFilledFormService
    {
        readonly ISubmittedForm _submitedForm;
        readonly ISubmittedQuestion _submittedQuestion;
        readonly SubmittedQuestionConverter _converter;
        
        readonly QuestionType[] NonAnswers = new QuestionType[] { QuestionType.Info};
        public FilledFormManager(ISubmittedForm submitedForm, ISubmittedQuestion submittedQuestion, SubmittedQuestionConverter converter)
        {
            _submitedForm = submitedForm;
            _submittedQuestion = submittedQuestion;
            _converter = converter;
        }

        public SubmitedFormModel GetForm(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveForm(SubmitedFormModel filledForm)
        {
            try
            {
                SubmittedForm submitForm = new SubmittedForm { Id = filledForm.Id ?? 0, ParticipantId = 1, PerosnalInfoShared = filledForm.PerosnalInfoShared ?? false, TemplateId = filledForm.TemplateId};
                var form = _submitedForm.Add(submitForm);
                if (form.IsSuccess)
                {
                    int id = form.Data?.Id??0;
                    IList<SubmittedQuestion> questions = filledForm.Questions?.Where(x => x.QuestionType != QuestionType.Info).Select(x => _converter.GetSubmitted(x, id)).ToList()?? new List<SubmittedQuestion>();
                    _submittedQuestion.Add(questions);
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
