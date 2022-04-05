using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model;
using Burakrzgr.MyForm.Entity.Model.AnswerTemplate;
using Burakrzgr.MyForm.Entity.Model.SubmittedForm;
using Newtonsoft.Json;

namespace Burakrzgr.MyForm.Business.QuestionManager
{
    public class SubmittedQuestionConverter
    {
        public SubmittedQuestionModel GetQuestion(SubmittedQuestion submittedQuestion,QuestionType type) 
        { 
            if(submittedQuestion != null)
            {
                var question = new SubmittedQuestionModel { Id = submittedQuestion.Id, AnsweredValue = submittedQuestion.Answer};
                switch (type)
                {
                    case QuestionType.Text:
                    case QuestionType.TextArea:
                      
                        break;
                    case QuestionType.RadioButton:
                    case QuestionType.ComboBox:
                        break;
                    case QuestionType.CheckBox:
                    case QuestionType.AcceptPolicy:
                        break;
                    case QuestionType.DateTime:
                        break;
                    case QuestionType.Rate:
                        break;
                    case QuestionType.Upload:
                        break;
                    case QuestionType.Info:
                        break;

                    default:
                        question.AnsweredValue = new { };
                        break;
                }
                return question;
            }
            else return new SubmittedQuestionModel { Id = 9999, AnsweredValue = "Database Error!",QuestionType = QuestionType.Info, TemplateId = 9999 };
        }

        internal SubmittedQuestion GetSubmitted(SubmittedQuestionModel model,int SubmittedFormId)
        {
            if (model != null)
            {
                SubmittedQuestion? question = new() { Id = model.Id??0, SubmittedFormId = SubmittedFormId, QuestionTemplateId = model.TemplateId };
                switch (model.QuestionType)
                {
                    case QuestionType.Text:
                    case QuestionType.TextArea:
                        question.Answer = model.AnsweredValue?.text??"";
                        break;
                    case QuestionType.RadioButton:
                        question.Choices = model.AnsweredValue?.selected.ToObject<string[]>();
                        break;
                    case QuestionType.ComboBox:
                        question.Answer = model.AnsweredValue?.picked?? "";
                        break;
                    case QuestionType.CheckBox:
                    case QuestionType.AcceptPolicy:
                        question.Answer = model.AnsweredValue?.@checked??"";
                        break;
                    case QuestionType.DateTime:
                        question.Answer = (model.AnsweredValue?.date ?? "") + "T"+ (model.AnsweredValue?.time??"");
                        break;
                    case QuestionType.Rate:
                        question.Answer = model.AnsweredValue?.stars;
                        break;
                    case QuestionType.Upload:
                        question.Choices = model.AnsweredValue?.filePath.ToObject<string[]>();
                        break;
                    case QuestionType.Info:
                        break;
                    default:
                        break;
                }
                return question;
            }
            else return new SubmittedQuestion { Id = 9999, Answer = "Database Error!", SubmittedFormId = 9999};
        }
    }
}
