using System.Web;
using System.Web.Compilation;
using System.Web.UI;

namespace Mvc.Framework
{
    /// <summary>
    /// ASP.Net页面路由处理
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public class PageRouteHandler : IRouteHandler
    {
        private string filePath;

        public PageRouteHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public IHttpHandler GetHttpHandler(HttpRequestContext requestContext)
        {            
            return BuildManager.CreateInstanceFromVirtualPath(filePath, typeof(Page)) as Page;
        }
    }
}
