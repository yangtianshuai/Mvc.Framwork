namespace Mvc.Framework
{
    public interface IController
    {
        void Execute(HttpRequestContext requestContext);
    }
}