using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Core
{
    public class SuccessResult<T> : IResult<T>
    {
        public SuccessResult(T data)
        {
            Data=data;
        }
        public bool IsSuccess { get => true; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
