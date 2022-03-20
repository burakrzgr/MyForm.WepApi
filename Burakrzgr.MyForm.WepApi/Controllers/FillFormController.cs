using Burakrzgr.MyForm.Business.FormTemplate;
using Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate;
using Microsoft.AspNetCore.Mvc;

namespace Burakrzgr.MyForm.WepApi.Controllers
{  
    [ApiController]
    [Route("[controller]")]
    public class FillFormController : Controller
    {
        private readonly ILogger<FormController> _logger;
        private readonly IFormService _formService;

        public FillFormController(ILogger<FormController> logger, IFormService formService)
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
