using Burakrzgr.MyForm.Business.History;
using Burakrzgr.MyForm.Entity.Model.CompletedForm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Burakrzgr.MyForm.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        IHistoryService _historyService;
        public OperationController(IHistoryService historyService)
        {
           
        }

        [HttpGet, Route("")]
        public IList<OperationModel> GetList()
        {
            var result = _historyService.GetOperationList();
            return result;
        }

    }
}
