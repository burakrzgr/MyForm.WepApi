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
    public interface IHistoryService
    {
        public IList<OperationModel> GetOperationList();
        public bool AddOperation(OperationModel operation);
        public SuccessResult<UserViewModel> RedirectToUser(int formId, int userId);
        public SuccessResult<IList<UserViewModel>> GetRedirectableUser(int formId);
    }
}
