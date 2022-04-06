using Burakrzgr.MyForm.Entity.Model.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Entity.Model.CompletedForm
{
    public class CompletedFormModel
    {
        public int Id { get; set; }
        public string? FormName { get; set; }
        public string? FormDesc { get; set; }
        public DateTime SubmitDate { get; set; } 
        public UserModal? CreatorUser { get; set; }
        public UserModal? SubmitterUser { get; set; }
        public IList<CompletedQuestion>? CompletedQuestions { get; set; }


    }
}
