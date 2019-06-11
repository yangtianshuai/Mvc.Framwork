namespace Mvc.Framework
{
    /// <summary>
    /// 控制器建造者
    /// 创建人：YTS
    /// 创建时间：2017-5-21
    /// </summary>
    public class ControllerBuilder
    {
        private static ControllerBuilder instance = new ControllerBuilder();
        private IControllerFactory _controllerFactoray;  
        
        internal ControllerBuilder()
        {
            //初始化模式控制器工厂
            _controllerFactoray = new DefaultControllerFactory();
        }

        /// <summary>
        /// 获取当前控制器建造者
        /// </summary>
        public static ControllerBuilder Current
        {
            get { return instance; }
        }

        public IControllerFactory GetControllerFactory()
        {
            return _controllerFactoray;
        }

        /// <summary>
        /// 依赖注入Controller工厂
        /// </summary>
        /// <param name="controllerFatory"></param>
        public void SetControllerFacotry(IControllerFactory controllerFatory)
        {
            _controllerFactoray = controllerFatory;
        }
    }
}