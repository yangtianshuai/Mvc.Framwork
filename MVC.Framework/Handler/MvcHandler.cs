using System;
using System.Web;

namespace Mvc.Framework
{
    /// <summary>
    /// MVC处理器
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public class MvcHandler : IHttpHandler
    {       
        public bool IsReusable { get; set; }

        private HttpRequestContext request;

        public MvcHandler(HttpRequestContext request)
        {
            this.request = request;
        }

        public void ProcessRequest(HttpContext context)
        {           
            //选择控制器工厂
            IControllerFactory controllerFactory = ControllerBuilder.Current.GetControllerFactory();

            //创建控制器实例
            IController controller = controllerFactory.CreateController(request, request.Controller);

            try
            {
                //执行
                controller.Execute(request);
            }
            catch(Exception ex)
            {
                context.Response.Write(ex.Message);
            }
            finally
            {
                controllerFactory.ReleaseController(controller);
            }
        }
    }
}