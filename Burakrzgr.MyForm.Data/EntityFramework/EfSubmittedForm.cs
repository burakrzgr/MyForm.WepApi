using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Burakrzgr.MyForm.Data.EntityFramework
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
            EntityEntry<SubmittedForm>? result = _factory.SubmittedForms.Add(form);
            _factory.SaveChanges();
            return (result.State == EntityState.Added) ? new SuccessResult<SubmittedForm>(result.Entity) : new ErrorResult<SubmittedForm>(result.Entity, "Db Error");
        }
    }
}
