using Newtonsoft.Json;
using System.Web;

namespace Mvc.Framework.Result
{
    public class JsonResult : ActionResult
    {
        public object Data { get; set; }

        public override void Result(ControllerContext controllerContext)
        {
            HttpResponse response = controllerContext.Controller.Request.Context.Response;

            response.ContentType = "application/json";

            response.Write(JsonConvert.SerializeObject(Data));
        }
    }
}