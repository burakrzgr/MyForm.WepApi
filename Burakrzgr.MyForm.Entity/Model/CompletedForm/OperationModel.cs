using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Entity.Model.CompletedForm
{
    public class OperationModel
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public OperationType OperationType { get; set; }
        public ConclutionType ConclutionType { get; set; }
        public int TargetId { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ConclutionDate { get; set; }
    }
}
