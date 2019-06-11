namespace Mvc.Framework
{
    public abstract class ActionResult
    {
        public abstract void Result(ControllerContext controllerContext);
    }
}