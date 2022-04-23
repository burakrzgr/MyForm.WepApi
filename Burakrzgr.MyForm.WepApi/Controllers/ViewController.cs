using Burakrzgr.MyForm.Business.Completed;
using Burakrzgr.MyForm.Entity.Model.CompletedForm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Burakrzgr.MyForm.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewController : Controller
    {
        readonly ICompletedFormService _completedFormService;
        public ViewController(ICompletedFormService completedFormService)
        {
            _completedFormService = completedFormService;
        }

        [HttpGet, Route("{id}")]
        public CompletedFormModel Get(int id)
        {
            var result = _completedFormService.GetForm(id);
            return result;
        }

        [HttpGet, Route("")]
        public IList<CompletedFormModel> GetList()
        {
            var result = _completedFormService.GetFormList();
            return result;
        }

    }
}
