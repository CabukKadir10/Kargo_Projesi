using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }
        public SuccessDataResult() : base(default, true)
        {

        }

        //public SuccessDataResult(T data)
        //{
        //    Data = data;
        //}

        //public SuccessDataResult(T data, string message)
        //{
        //    Data = data;
        //    Message = message;
        //}

        //public bool Success { get { return true; } }
        //public string Message { get; }
        //public T Data { get; }
    }
}
