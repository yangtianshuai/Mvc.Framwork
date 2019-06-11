using Mvc.Framework;

namespace Web
{
    public class PersonController : Controller
    {        
        public ActionResult Age()
        {
            PersonModel person = new PersonModel();
            person.Name = "张三";
            person.Age = 10;

            return View(person);
        }

        public ActionResult Say()
        {
            return Content("Hello World!");
        }        
    }
}