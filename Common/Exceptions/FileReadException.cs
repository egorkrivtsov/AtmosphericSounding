using System;
using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class FileReadException : Exception
    {
        public FileReadException()
        {
        }

        protected FileReadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public FileReadException(string message) : base(message)
        {
        }

        public FileReadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public FileReadException(string[] input):base($"Unable to parse: {String.Join(',',input)}")
        {
        }
    }
}
