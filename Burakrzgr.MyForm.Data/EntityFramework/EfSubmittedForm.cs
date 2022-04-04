using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model.FilledForm;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Entity.Entities
{
    public class EfSubmittedForm : ISubmittedForm
    {
        FormDbContext _factory;
        public EfSubmittedForm(FormDbContext factory)
        {
            _factory = factory;
        }
        public IResult<SubmittedForm> Add(SubmittedForm form)
        {
            EntityEntry<SubmittedForm>? result = null; // _factory. //FormTemplates.Add(form);
            return null;
            // _factory.SaveChanges();
           // return result.State == EntityState.Added ? new SuccessResult<FormTemplate>(result.Entity) : new ErrorResult<FormTemplate>(result.Entity, "Db Error");
        }
    }
}
