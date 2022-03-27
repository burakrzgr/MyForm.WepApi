using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.EntityFramework
{
    public class EfFormTemplate : IFormTemplate
    {
        FormDbContext _factory;
        public EfFormTemplate(FormDbContext factory)
        {
            _factory = factory;
        }
        public FormTemplate? Get(int id)
        {
            FormTemplate? formTemplate = _factory.FormTemplates.SingleOrDefault(x => x.Id == id);
            return formTemplate;
        }
        public FormTemplate? GetWithAnswer(int id)
        {
            var formTemplateList = _factory.FormTemplates.Join(_factory.QuestionTemplates,x => x.Id,y => y.TemplateId,(x,y) => x ).Where(x => x.Id == id).ToList();
            return formTemplateList.FirstOrDefault();
        }

        public IList<FormTemplate> GetAll()
        {
            IList<FormTemplate> formTemplateList = _factory.FormTemplates.ToList();
            return formTemplateList;
        }
    }
}
