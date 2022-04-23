using Burakrzgr.MyForm.Business.FormTemplate;
using Microsoft.AspNetCore.Mvc;
using Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate;

namespace Burakrzgr.MyForm.WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BroadcastController : Controller
    {
        private readonly ILogger<FormController> _logger;
        private readonly IFormTemplateService _formService;

        public BroadcastController(ILogger<FormController> logger, IFormTemplateService formService)
        {
            _logger = logger;
            _formService = formService;
        }

        [HttpGet, Route("{id}")]
        public Form Get(int id)
        {
            return _formService.GetForm(id);
        }

        [HttpGet, Route("")]
        public IEnumerable<Form> GetList()
        {
            return _formService.GetFormList();
        }
    }
}
