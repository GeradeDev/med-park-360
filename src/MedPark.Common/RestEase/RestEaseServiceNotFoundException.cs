using System;
using System.Collections.Generic;
using System.Text;

namespace MedPark.Common.RestEase
{
    public class RestEaseServiceNotFoundException : Exception
    {
        public string ServiceName { get; set; }

        public RestEaseServiceNotFoundException(string serviceName) : this(string.Empty, serviceName)
        {
        }

        public RestEaseServiceNotFoundException(string message, string serviceName) : base(message)
        {
            ServiceName = serviceName;
        }
    }
}
