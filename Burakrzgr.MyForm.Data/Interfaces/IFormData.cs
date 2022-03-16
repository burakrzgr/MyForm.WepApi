using Burakrzgr.MyForm.Entity.Model;

namespace Burakrzgr.MyForm.Data.Interfaces
{
    public interface IFormData
    {
        Form GetForm(int id);
        IList<Form> GetFormList();
    }
}
