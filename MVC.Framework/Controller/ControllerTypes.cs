using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Web.Compilation;

namespace Mvc.Framework
{
    /// <summary>
    /// 控制器类型管理者
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public class ControllerTypes
    {
        private static ICollection<Type> controllerTypes = new Collection<Type>();

        static ControllerTypes()
        {
            var assms = BuildManager.GetReferencedAssemblies();
            foreach (Assembly assembly in assms)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (typeof(IController).IsAssignableFrom(type))
                    {
                        controllerTypes.Add(type);
                    }
                }
            }
        }

        public static Type GetType(string controllerName)
        {
            foreach (var type in controllerTypes)
            {
                if (type.Name.ToLower().Equals(controllerName.ToLower()))
                {
                    return type;
                }
            }
            return null;
        }
    }
}