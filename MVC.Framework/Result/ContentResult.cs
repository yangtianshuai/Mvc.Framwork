using System;

namespace Mvc.Framework.Result
{
    public class ContentResult : ActionResult
    {
        public string Data { get; set; }

        public override void Result(ControllerContext controllerContext)
        {
            controllerContext.Controller.Request.Context.Response.Write(Data);
        }
    }
}