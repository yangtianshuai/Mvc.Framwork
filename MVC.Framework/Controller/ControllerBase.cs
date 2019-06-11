using System.Web;

namespace Mvc.Framework
{
    public class ControllerBase : IController
    {
        public IActionInvoker ActionInvoker { get; set; }

        public HttpRequestContext Request { get; set; }

        public string HttpVerb { get; set; }

        public ViewData ViewData { get; set; }

        /// <summary>
        /// 路径跳转
        /// </summary>
        /// <param name="url"></param>
        public void Redirect(string url)
        {
            Request.Context.Response.Redirect(url);
        }

        public virtual void Execute(HttpRequestContext requestContext)
        {
            if (ActionInvoker != null)
            {                
                ActionInvoker.InvokeAction(new ControllerContext(requestContext, this), requestContext.Action);
            }
        }
    }
}