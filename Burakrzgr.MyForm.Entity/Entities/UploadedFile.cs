using System;
using System.Collections.Generic;

namespace Burakrzgr.MyForm.Entity.Entities
{
    public partial class UploadedFile
    {
        public int Id { get; set; }
        public string UploadedFile1 { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string Extension { get; set; } = null!;
    }
}
