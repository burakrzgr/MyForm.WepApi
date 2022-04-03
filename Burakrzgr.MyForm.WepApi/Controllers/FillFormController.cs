using Burakrzgr.MyForm.Business.FilledForm;
using Burakrzgr.MyForm.Business.FormTemplate;
using Burakrzgr.MyForm.Entity.Model.FilledForm;
using Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate;
using Microsoft.AspNetCore.Mvc;

namespace Burakrzgr.MyForm.WepApi.Controllers
{  
    [ApiController]
    [Route("[controller]")]
    public class FillFormController : Controller
    {
        private readonly ILogger<FormController> _logger;
        private readonly IFilledFormService _formService;

        public FillFormController(ILogger<FormController> logger, IFilledFormService formService)
        {
            _logger = logger;
            _formService = formService;
        }

        [HttpGet, Route("{id}")]
        public Form Get(int id)
        {
            return null;
            //return _formService.GetForm(id);
        }

        [HttpGet, Route("")]
        public IEnumerable<Form> GetList()
        {
            return null;
            //return _formService.GetFormList();
        }
        [HttpPut, Route("")]
        public bool Put(FilledForm form)
        {
            if (form is null)
            {
                return false;
            }
            var result = _formService.SaveForm(form);

            return result;
        }
    }
}
