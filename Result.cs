using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Helpers
{
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public static Result Ok(string message = "") => new Result { Success = true, Message = message };
        public static Result Fail(string message) => new Result { Success = false, Message = message };
    }
}
