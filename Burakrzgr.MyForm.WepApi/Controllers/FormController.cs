using Burakrzgr.MyForm.Business.Model;
using Microsoft.AspNetCore.Mvc;

namespace Burakrzgr.MyForm.WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {
        private readonly ILogger<FormController> _logger;

        public FormController(ILogger<FormController> logger)
        {
            _logger = logger;
        }

        [HttpGet, Route("{id}")]
        public Form Get(int id)
        {
            return new Form() { Id = id };
        }

        [HttpGet, Route("")]
        public IEnumerable<Form> GetList()
        {
            return new Form[] { new Form() { Id = 1 }, new Form() { Id = 2 } };
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
