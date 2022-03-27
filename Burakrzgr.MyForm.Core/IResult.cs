using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Core
{
    public interface IResult<T>
    {
        public bool IsSuccess { get; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
