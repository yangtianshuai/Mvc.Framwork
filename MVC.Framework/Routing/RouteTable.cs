namespace Mvc.Framework
{
    /// <summary>
    /// 路由表
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public class RouteTable
    {
        /// <summary>
        /// 路由集合，存放所有自定义路由
        /// </summary>
        private static RouteCollection _instance = new RouteCollection();

        //单例模式
        public static RouteCollection Routes
        {
            get
            {
                return RouteTable._instance;
            }
        }
    }
}