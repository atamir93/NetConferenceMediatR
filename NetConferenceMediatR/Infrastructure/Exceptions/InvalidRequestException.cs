using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetConferenceMediatR.Infrastructure
{
    public class InvalidRequestException(string message) : Exception(message);
}
