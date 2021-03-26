using System;
using LogLibrary.Enums;

namespace LogLibrary.Models
{
    public class HttpLogModel
    {
        public string AppName { get; set; }
        public Direction Direction { get; set; }
        public DateTime RequestTime { get; set; }
        public string RequestIp { get; set; }
        public string RequestUri { get; set; }
        public string RequestQueryString { get; set; }
        public string RequestContentType { get; set; }
        public string RequestMethod { get; set; }
        public string RequestBody { get; set; }
        public string RequestCookies { get; set; }
        public string RequestHeader { get; set; }
        public DateTime ResponseTime { get; set; }
        public string ResponseBody { get; set; }
        public string ResponseStatusCode { get; set; }
        public string ResponseContentType { get; set; }
        public string ResponseHeader { get; set; }
    }
}