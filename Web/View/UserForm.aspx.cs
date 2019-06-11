using Mvc.Framework;
using System;

namespace MVC1.View
{
    public partial class UserForm : ViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserModel user = this.Model<UserModel>();
            if (user != null)
            {
                Response.Write("添加用户：" + user.Name);                
            }
        }
    }
}