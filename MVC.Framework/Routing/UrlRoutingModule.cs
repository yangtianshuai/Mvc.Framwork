using System;
using System.Web;

namespace Mvc.Framework
{
    /// <summary>
    /// URL路由管道
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public class UrlRoutingModule : IHttpModule
    {
        public void Dispose()
        {            
        }

        public void Init(HttpApplication context)
        {
            //注册ASP.Net管道缓存处理事件
            context.PostResolveRequestCache -= context_PostResolveRequestCache;
            context.PostResolveRequestCache += context_PostResolveRequestCache;
        }

        void context_PostResolveRequestCache(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
                      
            HttpRequestContext requestContext = new HttpRequestContext(context);

            try
            {           
                RouteData routeData = RouteTable.Routes.GetRouteData(requestContext);

                if (routeData == null)
                {                   
                    return;
                }
                
                requestContext.RouteData = routeData;

                IHttpHandler handler = routeData.RouteHandler.GetHttpHandler(requestContext);

                //为当前请求重定义Handler处理程序
                context.RemapHandler(handler);
            }
            catch(Exception ex)
            {
                if (context.IsCustomErrorEnabled)
                {
                    context.Response.Write(ex.Message + "<br/>");
                }
            }           
        }
    }
}
