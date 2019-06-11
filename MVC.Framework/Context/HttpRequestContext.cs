using System.Collections.Generic;
using System.Web;

namespace Mvc.Framework
{
    /// <summary>
    /// 请求上下文
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public class HttpRequestContext : RequestBase
    {
        public HttpRequestContext() : this(null)
        {
        }

        public HttpRequestContext(HttpContext context)
        {
            this.context = context;
        }

        private HttpContext context;

        public HttpContext Context
        {
            get
            {
                return context;
            }
            set
            {
                this.context = value;
            }
        }
    }
}