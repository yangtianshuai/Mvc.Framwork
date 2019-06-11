using System;
using System.Collections.Generic;
using System.Text;

namespace Mvc.Framework
{
    /// <summary>
    /// 抽象控制器工厂
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public interface IControllerFactory
    {
        IController CreateController(HttpRequestContext requestContext, string controllerName);
        void ReleaseController(IController controller);
    }
}
