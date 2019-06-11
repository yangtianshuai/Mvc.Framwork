using System.Collections.Generic;

namespace Mvc.Framework
{
    public abstract class RequestBase
    {
        public RouteData RouteData { get; set; }
        /// <summary>
        /// 获取或设置请求的Controller短名称
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// 获取或者设置请求的Action
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public Dictionary<string, object> Params { get; set; }
    }
}