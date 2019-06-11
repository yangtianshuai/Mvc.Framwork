using System;

namespace Mvc.Framework
{
    /// <summary>
    /// 动作回执器
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public interface IActionInvoker
    {
        void InvokeAction(ControllerContext controllerContext, string action);
    }
}
