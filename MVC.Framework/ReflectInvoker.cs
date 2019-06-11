using System;
using System.Reflection;

namespace Mvc.Framework
{
    /// <summary>
    /// 反射器
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public class ReflectInvoker
    {
        private Type _type;

        public ReflectInvoker(Type type)
        {
            this._type = type;
        }

        public MethodInfo[] GetMethods()
        {
            if (_type == null)
            {
                throw new Exception("未知类型，无法获取内部方法");
            }
            return _type.GetMethods();
        }        

        public MethodInfo GetMethod(string action,string[] keys)
        {            
            return GetMethod(action, keys, null);
        }

        public MethodInfo GetMethod(string action, string[] keys, object[] values)
        {
            action = action.ToLower();
            MethodInfo[] methods = this.GetMethods();
            foreach (MethodInfo method in methods)
            {
                if (method.Name.ToLower().Equals(action)
                    && IsMatch(method, keys, values))
                {
                    return method;
                }
            }
            return null;
        }

        public bool IsMatch(MethodInfo method, string[] names)
        {
            return IsMatch(method, names, null);
        }

        public bool IsMatch(MethodInfo method, string[] names, object[] values)
        {
            if (names == null || names.Length == 0)
            {
                return true;
            }
            if (values != null
                && names.Length != values.Length)
            {
                return false;
            }
            //进行参数匹配
            ParameterInfo[] _params = method.GetParameters();
            if (names.Length > _params.Length)
            {
                return false;
            }
            if (values != null
                && values.Length > _params.Length)
            {
                return false;
            }
            int step = 0;
            for (int i = 0; i < _params.Length; i++)
            {
                if (!_params[i + step].Name.ToLower().Equals(names[i].ToLower()))
                {
                    if (!_params[i + step].IsOptional)
                    {
                        return false;
                    }
                    for (int j = i + 1; j < _params.Length; j++)
                    {
                        if (_params[j].Name.ToLower().Equals(names[i].ToLower()))
                        {
                            step++;
                            break;
                        }
                        if (!_params[i + step].IsOptional)
                        {
                            return false;
                        }
                        if (values != null
                        && values[j].GetType().ReflectedType != _params[i + step].ParameterType)
                        {
                            return false;
                        }
                        step++;
                    }
                    return false;
                }
                if (values != null
                && values[i].GetType().ReflectedType != _params[i + step].ParameterType)
                {
                    return false;
                }
            }
            return true;
        }
    }
}