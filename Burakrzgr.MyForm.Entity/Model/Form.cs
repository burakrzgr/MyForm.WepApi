using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Entity.Model
{
    public class Form
    {

        public int Id { get; set; }
        public string? FormName { get; set; }
        public string? PersonellInfo { get; set; }
        public DateTime? DateofCreate { get; set; }
        public List<Question>? Questions { get; set; }

    }
}
