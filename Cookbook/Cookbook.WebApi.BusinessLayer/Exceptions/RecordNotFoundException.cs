using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.WebApi.BusinessLayer.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException()
        {

        }
        public RecordNotFoundException(string message) : base(message)
        {
        }
    }
}
