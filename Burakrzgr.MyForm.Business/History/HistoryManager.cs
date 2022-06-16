using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Entity.Model.Auth;
using Burakrzgr.MyForm.Entity.Model.CompletedForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Business.History
{
    public class HistoryManager : IHistoryService
    {
        public bool AddOperation(OperationModel operation)
        {
            throw new NotImplementedException();
        }

        public IList<OperationModel> GetOperationList()
        {
            throw new NotImplementedException();
        }

        public SuccessResult<IList<UserViewModel>> GetRedirectableUser(int formId)
        {
            throw new NotImplementedException();
        }

        public SuccessResult<UserViewModel> RedirectToUser(int formId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
