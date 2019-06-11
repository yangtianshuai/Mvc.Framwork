using Mvc.Framework;
using System;

namespace MVC1.View
{
    public partial class PersonFrom : ViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PersonModel person = this.Model<PersonModel>();
            if (person != null)
            {
                Response.Write("姓名：" + person.Name);
                Response.Write("年龄：" + person.Age);
            }
        }
    }
}