using Burakrzgr.MyForm.Business.History;
using Burakrzgr.MyForm.Entity.Model.CompletedForm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Burakrzgr.MyForm.Core;

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
        public IResult<string> RedirectToUser(int formId,int userId)
        {
            SuccessResult<string> res = _historyService.RedirectToUser(formId, userId);
            return res;
        }

        [HttpGet, Route("{formId}/Users")]
        public IResult<IList<string>> GetRedirectableUser(int formId)
        {
            SuccessResult<IList<string>> res = _historyService.GetRedirectableUser(formId);
            return res; 
        }

    }
}
