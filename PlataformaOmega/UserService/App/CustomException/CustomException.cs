using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace UserService.App.CustomExceptions
{
    public class CustomException : Exception
    {
        private string _Message { get; set; }
        public override string Message
        {
            get
            {
                return _Message;
            }
        }
        public CustomException()
        {

        }
    }
}
