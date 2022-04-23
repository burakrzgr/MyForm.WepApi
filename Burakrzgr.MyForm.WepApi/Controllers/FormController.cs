using Burakrzgr.MyForm.Business.FormTemplate;
using Burakrzgr.MyForm.Core;
using Burakrzgr.MyForm.Entity.Entities;
using Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Burakrzgr.MyForm.WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly ILogger<FormController> _logger;
        private readonly IFormTemplateService _formService;

        public FormController(ILogger<FormController> logger, IFormTemplateService formService)
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

        [HttpPost, Route("")]
        public bool Put(Form form)
        {
            if (form is null)
            {
                return false;
            }
            _formService.PutForm(form);
            return true;
        }
        [HttpPatch, Route("{id}")]
        public bool Patch(int id)
        {
            return id == 4;
        }

        [HttpDelete, Route("{id}")]
        public IResult<Form> Delete(int id)
        {
            return _formService.DeleteForm(id);
        }


    }
}
