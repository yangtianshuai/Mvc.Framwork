using System.Web;

namespace Mvc.Framework
{
    /// <summary>
    /// MVC路由处理
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public class MvcRouteHandler : IRouteHandler
    {
        public virtual IHttpHandler GetHttpHandler(HttpRequestContext requestContext)
        {            
            return new MvcHandler(requestContext);
        }
    }
}