using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Exceptions
{
    public class ParseException: Exception
    {
        public ParseException()
        {
        }

        protected ParseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ParseException(string message) : base(message)
        {
        }

        public ParseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ParseException(string[] input):base($"Unable to parse: {String.Join(',',input)}")
        {
        }
    }
}
