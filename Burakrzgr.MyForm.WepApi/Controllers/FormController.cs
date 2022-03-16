using Burakrzgr.MyForm.Business.Form;
using Burakrzgr.MyForm.Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Burakrzgr.MyForm.WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly ILogger<FormController> _logger;
        private readonly IFormService _formService;

        public FormController(ILogger<FormController> logger, IFormService formService)
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

        [HttpPost, Route("{id}")]
        public bool Post(int id)
        {
            return id == 5 ;
        }
        [HttpPut, Route("")]
        public bool Put()
        {
            return true;
        }
        [HttpPatch, Route("{id}")]
        public bool Patch(int id)
        {
            return id == 4;
        }

        [HttpDelete, Route("{id}")]
        public bool Delete(int id)
        {
            return id == 6;
        }


    }
}
