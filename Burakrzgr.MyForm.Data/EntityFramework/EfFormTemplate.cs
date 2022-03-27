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
        public FormTemplate Get(int id)
        {
            FormTemplate? formTemplate = _factory.FormTemplates.SingleOrDefault(x => x.Id == id);
            return formTemplate;
        }

        public IList<FormTemplate> GetAll()
        {
            IList<FormTemplate> formTemplateList = _factory.FormTemplates.ToList();
            return formTemplateList;
        }
    }
}
