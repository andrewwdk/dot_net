using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelService
{
    public class UserExistsException : Exception
    {
        public UserExistsException()
            : base()
        {

        }

        public UserExistsException(String message)
            : base(message)
        {

        }

        public UserExistsException(String message, Exception innerException) 
            : base(message, innerException)
        {

        }
    }
}
