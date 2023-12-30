using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Exceptions
{
    public class NotFoundExecption : ApplicationException
    {
        public NotFoundExecption(string name,object key) : base($"{name} - {key} not found !")
        {
        }
    }
}
