using System;
using System.Collections.Generic;
using System.Text;

namespace MedPark.Common.Types
{
    public class MedParkException : Exception
    {
        public string Code { get; }

        public MedParkException()
        {
        }


        public MedParkException(string code)
        {
            Code = code;
        }

        public MedParkException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public MedParkException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public MedParkException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public MedParkException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
