using Mvc.Framework;
using SC.Factory;
using SC.IBLL;
using SC.Model;
using System;
using System.Collections.Generic;
using System.Web;

namespace Web
{
    public class UserController : Controller
    {
        public ActionResult Add()
        {
            User user = new User();
            user.Name = "李四";
            BLLFactory.GetUser().AddUser(user);           

            UserModel userModel = new UserModel()
            {
                Name = user.Name
            };
            return View(userModel);
        }

        public ActionResult Add(string name)
        {
            User user = new User();
            user.Name = name;
            BLLFactory.GetUser().AddUser(user);
            UserModel userModel = new UserModel()
            {
                Name = user.Name
            };
            return View(userModel);
        }
    }
}