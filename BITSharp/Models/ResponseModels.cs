using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BITSharp.Models
{
    public class BitResponse<T>
    {
        public T Value { get; set; }
        public List<Error> Errors { get; set; }
    }

    public class Error
    {
        public string Value { get; set; }
    }
}
