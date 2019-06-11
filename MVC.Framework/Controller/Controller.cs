using Mvc.Framework.Result;
using System;
using System.IO;

namespace Mvc.Framework
{
    public abstract class Controller : ControllerBase, IDisposable
    {               
        public Controller()
        {
            base.ActionInvoker = new ControllerActionInvoker();
        }
        public ActionResult Content(string content)
        {
            return new ContentResult { Data = content };
        }

        public ActionResult Json(object data)
        {
            return new JsonResult { Data = data };
        }
        
        public ActionResult View(object model)
        {           
            return new ViewResult { Data = model };
        }      

        public void RedirectResult(string url)
        {
            url = Request.Context.Server.MapPath("" + url);
            using (StreamReader sr = new StreamReader(url))
            {
                Content(sr.ReadToEnd());
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
        }
    }
}