using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Mvc.Framework
{
    /// <summary>
    /// 默认控制器工厂
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public class DefaultControllerFactory : IControllerFactory
    {
        private static ICollection<Type> controllerTypes = new Collection<Type>();

        public virtual IController CreateController(HttpRequestContext requestContext, string controllerName)
        {
            Type controllerType = ControllerTypes.GetType(controllerName + "controller");

            if (controllerType != null)
            {
                var controller = Activator.CreateInstance(controllerType) as Controller;

                //设置输出对象
                controller.Request = requestContext;
                //设置请求方法
                controller.HttpVerb = requestContext.Context.Request.HttpMethod.ToLower();

                return Activator.CreateInstance(controllerType) as IController;

            }
            return null;
        }

        public void ReleaseController(IController controller)
        {            
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}