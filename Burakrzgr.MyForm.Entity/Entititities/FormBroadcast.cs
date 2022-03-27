using System;
using System.Collections.Generic;

namespace Burakrzgr.MyForm.WepApi
{
    public partial class FormBroadcast
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int BroadcasterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}
