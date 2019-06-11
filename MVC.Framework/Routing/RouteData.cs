namespace Mvc.Framework
{
    public class RouteData
    {
        public IRouteHandler RouteHandler { get; set; }

        public RouteBase Route { get; set; }        

        public RouteData()
        {
        }
        public RouteData(RouteBase route, IRouteHandler routeHandler)
        {
            this.Route = route;
            this.RouteHandler = routeHandler;
        }
    }
}