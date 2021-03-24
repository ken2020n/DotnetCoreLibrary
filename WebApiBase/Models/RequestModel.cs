using System.Collections.Generic;

namespace WebApiBase.Models
{
    public class RequestModel<T>
    {
        public string ApiKey { get; set; }

        public string Signature { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}