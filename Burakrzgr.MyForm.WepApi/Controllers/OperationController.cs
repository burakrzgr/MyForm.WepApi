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
        //IHistoryService _historyService;
        public OperationController()//IHistoryService historyService
        {
           
        }

        [HttpGet, Route("{formId}")]
        public IList<OperationModel> GetList(int formId)
        {
            var result = new List<OperationModel> { };// _historyService.GetOperationList();
            return result;
        }

        [HttpPost, Route("{formId}/Redirect/{userId}")]
        public IResult<string> RedirectToUser(int formId,int userId)
        {
            return new SuccessResult<string>("Success!"+formId+" "+userId);
        }

        [HttpGet, Route("{formId}/Users")]
        public IResult<IList<string>> GetRedirectableUser(int formId)
        {
            return new SuccessResult<IList<string>>(new List<string> { "User 1","Userr 2","User "+formId });
        }

    }
}
