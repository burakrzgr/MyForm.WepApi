using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.Memory
{
    //public class MemQuestionData : IQuestionData
    //{
    //    private readonly IList<Question> Data = new List<Question>() { new Question { Id = 1, FormId = 1, QuestionText = "Quest 1",QuestionType = QuestionType.Text }, new Question { Id = 2, FormId = 1, QuestionText = "Quest 2", QuestionType = QuestionType.Text }, new Question { Id = 3, FormId = 1, QuestionText = "Quest 3", QuestionType = QuestionType.TextArea }, new Question { Id = 4, FormId = 2, QuestionText = "Quest Another", QuestionType = QuestionType.Text } };

    //    public Question GetQuestion(int id)
    //    {
    //        var res = Data.FirstOrDefault(x => x.Id == id);
    //        if (res == null)
    //            throw new Exception("No id Found");
    //        return res;
    //    }

    //    public List<Question>? GetQuestionWithFormId(int formId)
    //    {
    //        List<Question>? res = Data.Where(x => x.FormId == formId).ToList();
    //        if (res == null)
    //            throw new Exception("No id Found");
    //        return res;
    //    }
    //}
}
