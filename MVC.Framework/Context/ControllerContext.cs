namespace Mvc.Framework
{
    public class ControllerContext
    {
        public RequestBase RequestContext { get; set; }        

        public virtual ControllerBase Controller { get; set; }

        public ControllerContext()
        {

        }
        public ControllerContext(RequestBase reqestContext, ControllerBase controller)
        {
            RequestContext = reqestContext;
            Controller = controller;
        }
    }
}
