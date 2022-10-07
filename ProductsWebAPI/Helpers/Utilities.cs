using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebAPI.Helpers
{
    public class Utilities
    {
        public static List<string> GetExceptionDetails(Exception exception)
        {            
            List<string> errors = new List<string>();
            Exception innerException = exception;

            errors.Add(exception.Message);
            
            while(innerException.InnerException != null)
            {
                innerException = innerException.InnerException;
                errors.Add(innerException.Message);
            }

            return errors;
        }
    }
}
