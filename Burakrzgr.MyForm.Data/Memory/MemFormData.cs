using Burakrzgr.MyForm.Data.Interfaces;
using Burakrzgr.MyForm.Entity.Model;
using Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Data.Memory
{
    public class MemFormData : IFormData
    {
        private readonly IList<Form> Data = new List<Form>() { new Form { Id = 1, FormName = "Test 1", DateofCreate = new DateTime(1989,07,19) ,PersonalInfo = 0 }, new Form { Id = 2, FormName = "Test 2",PersonalInfo = 2 }, new Form { Id = 3, FormName = "Test 3" , PersonalInfo = 1 } , new Form { Id = 4, FormName = "Test 4", PersonalInfo = 1 } };


        public Form GetForm(int id)
        {
            var form = Data.Where(x => x.Id == id).FirstOrDefault();
            if (form == null)
                throw new ArgumentException("Cant Find Model with id" + id);
            return form;
        }
        public IList<Form> GetFormList()
        {
            return Data;
        }
    }
}
