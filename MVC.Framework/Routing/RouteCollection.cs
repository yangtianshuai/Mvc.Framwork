using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Mvc.Framework
{
    /// <summary>
    /// 路由集合
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public class RouteCollection : Collection<RouteBase>
    {
        private Dictionary<string, RouteBase> maps = new Dictionary<string, RouteBase>();

        public RouteBase this[string name]
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                {
                    return null;
                }
                RouteBase result;
                if (this.maps.TryGetValue(name, out result))
                {
                    return result;
                }
                return null;
            }
        }

        public void Add(string name, RouteBase route)
        {
            base.Add(route);
            if (!string.IsNullOrEmpty(name))
            {
                this.maps[name] = route;
            }
        }

        public Route MapPageRoute(string routeName, string routeUrl, string filePath)
        {            
            Route route = new Route(routeUrl, new PageRouteHandler(filePath));            
            this.Add(routeName, route);
            return route;
        }

        public Route MapPageRoute(string routeName, string filePath, string controller, string action)
        {
            Route route = new Route(filePath, new MvcRouteHandler());
            route.Contoller = controller;
            route.Action = action;
            this.Add(routeName, route);
            return route;
        }

        public void ClearAll()
        {
            base.Clear();
            this.maps.Clear();
        }

        public RouteData GetRouteData(HttpRequestContext requestContext)
        {            
            foreach (RouteBase current in this)
            {
                RouteData routeData = current.GetRouteData(requestContext);
                if (routeData != null)
                {
                    return routeData;
                }
            }
            return null;
        }
    }
}