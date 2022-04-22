using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        public FormTemplate? Delete(int id)
        {
            FormTemplate? formTemplate = _factory.FormTemplates.SingleOrDefault(x => x.Id == id);
            if (formTemplate != null) {
                formTemplate.Deleted = true;               
                _factory.FormTemplates.Update(formTemplate); 
                _factory.SaveChanges();
            }
            return formTemplate;
        }

        public IList<FormTemplate> GetAll()
        {
            IList<FormTemplate> formTemplateList = _factory.FormTemplates.Where(x => (!x.Deleted)).ToList();
            return formTemplateList;
        }
        public IResult<FormTemplate> Add(FormTemplate form)
        {
            EntityEntry<FormTemplate>? result = _factory.FormTemplates.Add(form);
            _factory.SaveChanges();
            return (result.State == EntityState.Added || result.State == EntityState.Unchanged) ? new SuccessResult<FormTemplate>(result.Entity) : new ErrorResult<FormTemplate>(result.Entity, "Db Error");
        }

    }
}
