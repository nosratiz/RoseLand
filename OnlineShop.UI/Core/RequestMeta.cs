using System;

namespace OnlineShop.UI.Core
{
    public class RequestMeta : IRequestMeta
    {
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public string Browser { get; set; }
        public string Os { get; set; }
        public string Device { get; set; }
    }
}