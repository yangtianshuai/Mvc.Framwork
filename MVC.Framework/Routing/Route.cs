using System.Collections.Generic;
using System.IO;

namespace Mvc.Framework
{
    public class Route : RouteBase
    {      
        public string Contoller { get; set; }

        public string Action { get; set; }

        public string[] Param { get; set; }
        
        private string preUrl;
        /// <summary>
        /// 前置请求路径
        /// </summary>
        public string PreUrl
        {
            get
            {
                return this.preUrl;
            }
            set
            {
                this.preUrl = value;
                this.preUrl = this.preUrl.TrimStart('/').TrimEnd('/');
            }
        }       

        public IRouteHandler RouteHandler { get; set; }

        public Route(string url, IRouteHandler routeHandler)
            :this(url, routeHandler,"","")
        { }
        public Route(IRouteHandler routeHandler, string contoller, string action)
            : this("", routeHandler, contoller, action, new string[] { })
        { }
        public Route(string url, IRouteHandler routeHandler, string contoller, string action)
            : this(url, routeHandler, contoller, action, new string[] { })
        { }
        public Route(string url, IRouteHandler routeHandler, string contoller, string action, string[] param)
        {
            this.preUrl = "";
            this.Url = url;
            this.RouteHandler = routeHandler;
            this.Contoller = contoller;
            this.Action = action;
            this.Param = param;
        }

        public override RouteData GetRouteData(HttpRequestContext requestContext)
        {
            string requestUrl = requestContext.Context.Request.AppRelativeCurrentExecutionFilePath.Substring(2);
            
            try
            {
                string file = requestContext.Context.Server.MapPath("../" + requestUrl);
                if (File.Exists(file))
                {                    
                    return null;
                }
            }
            catch
            { }

            int num = requestUrl.IndexOf('?');
            if (num > 0)
            {
                requestUrl = requestUrl.Substring(0, num);
            }
            requestUrl = requestUrl.ToLower();

            RouteData routeData = new RouteData(this, this.RouteHandler);

            string url = this.Url;
            if (Contoller.Length > 0  && Action.Length > 0)
            {
                url = Contoller + "/" + Action;
            }           

            if(preUrl.Length>0)
            {
                url = PreUrl + "/" + url;
            }
            url = url.ToLower();

            requestContext.Params = new Dictionary<string, object>();

            if (this.Param.Length == 0)
            {                
                if (requestContext.Context.Request.HttpMethod.ToLower().Equals(HttpVerb.Get))
                {
                    //遍历QueryString
                    foreach (string key in requestContext.Context.Request.QueryString.AllKeys)
                    {
                        requestContext.Params.Add(key, requestContext.Context.Request.QueryString[key]);
                    }                   
                }
                else
                {
                    //遍历Forms
                    foreach (string key in requestContext.Context.Request.Form.AllKeys)
                    {
                        requestContext.Params.Add(key, requestContext.Context.Request.Form[key]);
                    }
                }
            }
            //处理带参数链接
            if (requestUrl.StartsWith(url))
            {                
                string param = requestUrl.Replace(url + "/", "");
                if (param.Length > 0 && this.Param.Length > 0)
                {
                    string[] arrays = param.Split('/');
                    if (arrays.Length > this.Param.Length)
                    {
                        //参数个数不正确
                        return null;                        
                    }
                    else
                    {
                        for (int i = 0; i < arrays.Length; i++)
                        {
                            requestContext.Params.Add(this.Param[i], arrays[i]);
                        }
                        requestUrl = url;
                    }
                }
            }
            else
            {               
                return null;
            }

            if (requestUrl.Equals(url))
            {
                requestContext.Controller = this.Contoller;

                requestContext.Action = this.Action;                
            }           
            return routeData;
        }
    }
}