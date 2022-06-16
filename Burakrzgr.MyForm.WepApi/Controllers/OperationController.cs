using Burakrzgr.MyForm.Business.History;
using Burakrzgr.MyForm.Entity.Model.CompletedForm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Entity.Model.Auth;

namespace Burakrzgr.MyForm.WepApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        IHistoryService _historyService;
        public OperationController(IHistoryService historyService)
        {
           
        }

        [HttpGet, Route("{formId}")]
        public IList<OperationModel> GetList(int formId)
        {
            var result = _historyService.GetOperationList();
            return result;
        }

        [HttpPost, Route("{formId}/Redirect/{userId}")]
        public IResult<UserViewModel> RedirectToUser(int formId,int userId)
        {
            SuccessResult<UserViewModel> res = _historyService.RedirectToUser(formId, userId);
            return res;
        }

        [HttpGet, Route("{formId}/Users")]
        public IResult<IList<UserViewModel>> GetRedirectableUser(int formId)
        {
            SuccessResult<IList<UserViewModel>> res = _historyService.GetRedirectableUser(formId);
            return res; 
        }

    }
}
