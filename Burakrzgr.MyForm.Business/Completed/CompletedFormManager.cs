using Burakrzgr.MyForm.Business.QuestionManager;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model.Auth;
using Burakrzgr.MyForm.Entity.Model.CompletedForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Business.Completed
{
    public class CompletedFormManager : ICompletedFormService
    {
        readonly ISubmittedForm _submitedForm;
        readonly ISubmittedQuestion _submittedQuestion;
        readonly SubmittedQuestionConverter _converter;
        readonly IOptionsTemplateDal _optionsTemplate;
        readonly IFormTemplateDal _formTemplate;
        readonly IQuestionTemplate _questionTemplate;

        //  readonly QuestionType[] NonAnswers = new QuestionType[] { QuestionType.Info};
        //  readonly int[] _choiceQuestions = new int[] { (int)QuestionType.RadioButton, (int)QuestionType.ComboBox, (int)QuestionType.Upload };
        public CompletedFormManager(ISubmittedForm submitedForm, ISubmittedQuestion submittedQuestion, SubmittedQuestionConverter converter, IOptionsTemplateDal optionsTemplate,IFormTemplateDal formTemplate,IQuestionTemplate questionTemplate)
        {
            _submitedForm = submitedForm;
            _submittedQuestion = submittedQuestion;
            _converter = converter;
            _optionsTemplate = optionsTemplate;
            _formTemplate = formTemplate;
            _questionTemplate = questionTemplate;
        }
        public CompletedFormModel GetForm(int id)
        {
            var res = _submitedForm.Get(id);
            if (res.IsSuccess && res.Data is not null)
            {
                SubmittedForm form = res.Data;
                var fTemplate = _formTemplate.Get(form.TemplateId);

                var qTemplate = _questionTemplate.Get(form.TemplateId);
                var answers = _submittedQuestion.Get(form.Id);

                var completedAnswers = answers.Data?.Join(qTemplate, x => x.QuestionTemplateId, y => y.Id, (x, y) => 
                    new CompletedQuestion { Id = x.Id, QuestionText = y.QuestionText, QuestionDetail = "", QuestionType = (QuestionType)y.QuestionType, Answer = x.Answer ?? "" }).ToList();


                CompletedFormModel model = new CompletedFormModel
                {
                    Id = form.Id,
                    PersonalInfoShared = form.PersonalInfoShared,
                    SubmitterUser = form.PersonalInfoShared ? new UserModal { UserId = form.ParticipantId } : null,
                    FormName = fTemplate.FormName,
                    FormDesc = fTemplate.FormDesc,
                    SubmitDate = DateTime.Now,
                    CreatorUser = new UserModal { UserId = fTemplate.CreatorId },
                    CompletedQuestions = completedAnswers,
                };

                return model;
            }
            else
            {
                return new CompletedFormModel { };
            }

        }

        public IList<CompletedFormModel> GetFormList()
        {
            var res = _submitedForm.GetList();
            if (res.IsSuccess && res.Data is not null) 
            {
                var fTemplate = _formTemplate.GetAll();
                return res.Data.Join(fTemplate, form => form.TemplateId, tmp => tmp.Id ,(form,tmp) => new CompletedFormModel
                {
                    Id = form.Id,
                    PersonalInfoShared = form.PersonalInfoShared,
                    SubmitterUser = form.PersonalInfoShared ? new UserModal { UserId = form.ParticipantId } : null,
                    FormName = tmp.FormName,
                    FormDesc = tmp.FormDesc,
                    SubmitDate = DateTime.Now,
                    CreatorUser = new UserModal { UserId = tmp.CreatorId }
                }).ToList();
            }
            return new List<CompletedFormModel>();
        }
    }
}
