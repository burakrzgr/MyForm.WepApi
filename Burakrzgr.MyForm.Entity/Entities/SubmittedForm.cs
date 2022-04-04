using System;
using System.Collections.Generic;

namespace Burakrzgr.MyForm.Entity.Entities
{
    public partial class SubmittedForm
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int ParticipantId { get; set; }
        public bool PerosnalInfoShared { get; set; }
    }
}
