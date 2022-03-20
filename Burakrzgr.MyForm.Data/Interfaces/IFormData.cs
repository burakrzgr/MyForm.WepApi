using Burakrzgr.MyForm.Entity.Model.FormTemplate.FormTemplate;

namespace Burakrzgr.MyForm.Data.Interfaces
{
    public interface IFormData
    {
        Form GetForm(int id);
        IList<Form> GetFormList();
    }
}
