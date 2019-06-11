using Mvc.Framework;
using System;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //简单路由  http://localhost:51007/test
            RouteTable.Routes.MapPageRoute("test", "test", "~/View/TestForm.aspx");

            //MVC  http://localhost:51007/person/age
            RouteTable.Routes.MapPageRoute("person-age", "~/View/PersonFrom.aspx", "person", "age");

            //MVC + 三层 http://localhost:51007/user/add
            RouteTable.Routes.MapPageRoute("user-add", "~/View/UserForm.aspx", "user", "add");

            //MVC + 参数 + 三层 http://localhost:51007/api/user/add/马云
            Route route = new Route("~/View/UserForm.aspx", new MvcRouteHandler(), "user", "add")
            {
                PreUrl = "api",
                Param = new string[] { "name" }
            };
            RouteTable.Routes.Add("user-add2", route);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}