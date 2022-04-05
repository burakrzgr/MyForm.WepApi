using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model;
using Burakrzgr.MyForm.Entity.Model.AnswerTemplate;
using Newtonsoft.Json;

namespace Burakrzgr.MyForm.Business.QuestionManager
{
    public class QuestionTemplateConverter
    {
        public Question GetQuestion(QuestionTemplate template) 
        { 
            if(template != null)
            {
                var question = new Question { Id = template.Id, FormId = template.TemplateId, QuestionText = template.QuestionText, QuestionType = (QuestionType)template.QuestionType };
                switch ((QuestionType)template.QuestionType)
                {
                    case QuestionType.Text:
                    case QuestionType.TextArea:
                        question.AnswerArea = new TextAnswerArea { DefaultText = template.AnswerStr1, TextHeight = template.AnswerInt1 };
                        break;
                    case QuestionType.RadioButton:
                    case QuestionType.ComboBox:
                        question.AnswerArea = new OptionsAnswerArea { Options = template.StrArray, Multi = template.AnswerBool1?? false };
                        break;
                    case QuestionType.CheckBox:
                    case QuestionType.AcceptPolicy:
                        question.AnswerArea = new CheckAnswerArea { DefaultChecked = template.AnswerBool1??false, CheckText = template.AnswerStr1??"", Description = template.AnswerStr2??"" };
                        break;
                    case QuestionType.DateTime:
                        question.AnswerArea = new DateTimeAnswerArea { CheckDate = template.AnswerBool1??false, CheckTime = template.AnswerBool2??false };
                        break;
                    case QuestionType.Rate:
                        question.AnswerArea = new RateAnswerArea { Stars = template.AnswerInt1 ?? 5 };
                        break;
                    case QuestionType.Upload:
                        question.AnswerArea = new UploadArea { FileTypes = template.StrArray ?? Array.Empty<string>() };
                        break;
                    case QuestionType.Info:
                        question.AnswerArea = new InfoArea { Variant = template.AnswerStr1 ?? "info", Dismissive = template.AnswerBool1 ?? false };
                        break;

                    default:
                        question.AnswerArea = new { };
                        break;
                }
                return question;
            }
            else return new Question { Id = 9999, QuestionText = "Database Error!",FormId = 9999,QuestionType = QuestionType.Info };
        }

        internal QuestionTemplate GetTemplate(Question question, int templateId)
        {
            if (question != null)
            {
                var template = new QuestionTemplate { Id = question.Id, TemplateId = templateId, QuestionText = question.QuestionText ?? "", QuestionType = (int)question.QuestionType };
                switch ((QuestionType)template.QuestionType)
                {
                    case QuestionType.Text:
                    case QuestionType.TextArea:
                        template.AnswerStr1 = question.AnswerArea?.defaultText;
                        template.AnswerInt1 = question.AnswerArea?.textHeight;
                        break;
                    case QuestionType.RadioButton:
                        template.AnswerBool1 = question.AnswerArea?.multi;
                        template.StrArray = question.AnswerArea?.options.ToObject<string[]>();
                        break;
                    case QuestionType.ComboBox:
                        template.StrArray = question.AnswerArea?.options.ToObject<string[]>();
                        break;
                    case QuestionType.CheckBox:
                    case QuestionType.AcceptPolicy:
                        template.AnswerBool1 = question.AnswerArea?.defaultChecked;
                        template.AnswerStr1 = question.AnswerArea?.checkText ?? "";
                        template.AnswerStr2 = question.AnswerArea?.description ?? "";
                        break;
                    case QuestionType.DateTime:
                        template.AnswerBool1 = question?.AnswerArea?.checkDate;
                        template.AnswerBool2 = question?.AnswerArea?.checkTime;
                        break;
                    case QuestionType.Rate:
                        template.AnswerInt1 = question?.AnswerArea?.stars;
                        break;
                    case QuestionType.Upload:
                        template.StrArray = question.AnswerArea?.fileTypes.ToObject<string[]>();
                        break;
                    case QuestionType.Info:
                        template.AnswerStr1 = question?.AnswerArea?.variant;
                        template.AnswerBool1 = question?.AnswerArea?.dismissive;
                        break;
                    default:
                        break;
                }
                return template;
            }
            else return new QuestionTemplate { Id = 9999, QuestionText = "Database Error!", TemplateId = 9999, QuestionType = 0 };
        }
    }
}
