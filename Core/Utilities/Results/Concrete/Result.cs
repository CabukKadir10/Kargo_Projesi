using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(bool succes)
        {
            Success = succes;
        }
        public Result(bool succes, string message) : this(succes)
        {
            Message = message;
        }
        public bool Success { get; }
        public string Message { get; }
    }
}
