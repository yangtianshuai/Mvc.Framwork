using System;
using System.Web;
using System.Web.Compilation;

namespace Mvc.Framework.Result
{
    public class ViewResult : ActionResult
    {        
        public object Data { get; set; }

        public override void Result(ControllerContext controllerContext)
        {            
            try
            {
                //显示View
                ViewPage page = (ViewPage)BuildManager.CreateInstanceFromVirtualPath(
                            controllerContext.RequestContext.RouteData.Route.Url, typeof(ViewPage));
                page.ViewData = new ViewData();                
                page.ViewData.Model = Data;

                page.ProcessRequest(HttpContext.Current);                
            }
            catch(Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
        }
    }
}