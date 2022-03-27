using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model;
using Burakrzgr.MyForm.Entity.Model.Questions;

namespace Burakrzgr.MyForm.Business.QuestionManager
{
    public class QuestionConverter
    {
        public Question GetQuestion(QuestionTemplate template) 
        { 
            if(template != null)
            {
                switch ((QuestionType)template.QuestionType)
                {
                    case QuestionType.Text:
                    case QuestionType.TextArea:
                        return new TextQuestion { Id = template.Id, FormId = template.TemplateId, QuestionText = template.QuestionText, QuestionType = QuestionType.Text, DefaultText = template.AnswerStr1, TextHeight = template.AnswerInt1 };

                    default: return new Question { Id = template.Id, FormId = template.TemplateId, QuestionText = template.QuestionText, QuestionType = (QuestionType)template.QuestionType };
                
                }
            }
            else return new Question { Id = 9999, QuestionText = "Database Error!",FormId = 9999,QuestionType = QuestionType.Info };
        }
    }
}
