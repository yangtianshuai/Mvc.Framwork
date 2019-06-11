using System.Reflection;

namespace Mvc.Framework
{
    /// <summary>
    /// 动作回执器
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public class ControllerActionInvoker : IActionInvoker
    {
        public void InvokeAction(ControllerContext controllerContext, string action)
        {            
            ReflectInvoker reflect = new ReflectInvoker(controllerContext.Controller.GetType());

            string[] keys = new string[controllerContext.RequestContext.Params.Keys.Count];

            controllerContext.RequestContext.Params.Keys.CopyTo(keys, 0);

            MethodInfo method = reflect.GetMethod(action,keys);//获取匹配方法

            object[] values = new object[controllerContext.RequestContext.Params.Values.Count];

            controllerContext.RequestContext.Params.Values.CopyTo(values, 0);

            //进行参数匹配
            object result = method.Invoke(controllerContext.Controller, values);
            if(result is ActionResult)
            {
                //返回结果
                (result as ActionResult).Result(controllerContext);
            }           
        }
    }
}