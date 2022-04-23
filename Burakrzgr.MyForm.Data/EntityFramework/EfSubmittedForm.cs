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
            return (result.State == EntityState.Added || result.State == EntityState.Unchanged) ? new SuccessResult<SubmittedForm>(result.Entity) : new ErrorResult<SubmittedForm>(result.Entity, "Db Error");
        }

        public IResult<SubmittedForm> Get(int id)
        {
            var item = _factory.SubmittedForms.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return new ErrorResult<SubmittedForm>(new SubmittedForm(), "Cant Find Submitted Form with id:" + id);
            return new SuccessResult<SubmittedForm>(item);
        }
    }
}
