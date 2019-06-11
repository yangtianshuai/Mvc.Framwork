using System.Web;

namespace Mvc.Framework
{
    public interface IRouteHandler
    {
        IHttpHandler GetHttpHandler(HttpRequestContext requestContext);
    }
}