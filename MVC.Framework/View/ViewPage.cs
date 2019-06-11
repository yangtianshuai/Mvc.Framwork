using System.Web.UI;

namespace Mvc.Framework
{
    public class ViewPage : Page
    {              
        public ViewData ViewData { get; set; }

        public T Model<T>()
        {
            return (T)ViewData.Model;
        }

        public HtmlTextWriter Writer { get; private set; }        

        protected override void Render(HtmlTextWriter writer)
        {
            Writer = writer;
            try
            {
                base.Render(writer);
            }
            finally
            {
                Writer = null;
            }
        }
    }
}