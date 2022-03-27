using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burakrzgr.MyForm.Core
{
    public class ErrorResult<T> : IResult<T>
    {
        public ErrorResult(T data,string message)
        {
            Data = data;
            Message = message;
        }
        public bool IsSuccess { get => false; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
