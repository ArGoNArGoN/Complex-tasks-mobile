using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace project.Exceptions
{
    public class HttpClientException
        : Exception
    {
        public Dictionary<String, IEnumerable<String>> ErrorPropertys { get; } = new Dictionary<String, IEnumerable<String>>();
        public HttpClientException() { }
        public HttpClientException(string message) : base(message) { }
        public HttpClientException(string message, Exception innerException) : base(message, innerException) { }
        protected HttpClientException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HttpClientException(Dictionary<String, IEnumerable<String>> errorPropertys) : base() { ErrorPropertys = errorPropertys; }
    }
}
