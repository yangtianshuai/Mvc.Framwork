using System;

namespace MVC1.View
{
    public partial class TestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("我是测试页面");
        }
    }
}