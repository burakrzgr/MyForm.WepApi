using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model;
using Burakrzgr.MyForm.Entity.Model.AnswerTemplate;

namespace Burakrzgr.MyForm.Business.QuestionManager
{
    public class QuestionConverter
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
                        question.AnswerArea = new TextAnswerArea {  DefaultText = template.AnswerStr1, TextHeight = template.AnswerInt1 };
                        break;
                    default:
                        break;
                }
                return question;
            }
            else return new Question { Id = 9999, QuestionText = "Database Error!",FormId = 9999,QuestionType = QuestionType.Info };
        }
    }
}
