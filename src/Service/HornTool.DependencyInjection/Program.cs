namespace HornTool.Ioc
{
    /// <summary>
    /// 服务接口
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// 服务启动
        /// </summary>
        void OnStart();

        /// <summary>
        /// 服务停止
        /// </summary>
        void OnStop();
    }
}
