using System.Web;

namespace Mvc.Framework
{
    public abstract class RouteBase
    {
        /// <summary>
        /// 配置路由URL,如：{controller}/{action}/{id}
        /// </summary>
        public string Url { get; set; }

        public abstract RouteData GetRouteData(HttpRequestContext requestContext);
    }
}