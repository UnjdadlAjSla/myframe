
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFrame.RedisControl
{
    public class RedisManager
    {
        /// <summary>
        /// redis配置文件信息
        /// </summary>
        private static readonly RedisConfigInfo RedisConfigInfo = RedisConfigInfo.GetConfig();
        private static PooledRedisClientManager _prcm;
        /// <summary>
        /// 静态构造方法，初始化链接池管理对象
        /// </summary>
        static RedisManager()
        {
            CreateManager();
        }
        /// <summary>
        /// 创建链接池管理对象
        /// </summary>
        private static void CreateManager()
        {
            var writeServerList = RedisConfigInfo.WriteServerList.Split(',').ToList();
            var readServerList = RedisConfigInfo.ReadServerList.Split(',').ToList();

            _prcm = new PooledRedisClientManager(readServerList, writeServerList,
                             new RedisClientManagerConfig
                             {
                                 MaxWritePoolSize = RedisConfigInfo.MaxWritePoolSize,
                                 MaxReadPoolSize = RedisConfigInfo.MaxReadPoolSize,
                                 AutoStart = RedisConfigInfo.AutoStart,
                             });
        }
        private static IEnumerable<string> SplitString(string strSource, string split)
        {
            return strSource.Split(split.ToArray());
        }
        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        public static IRedisClient GetClient()
        {
            if (_prcm == null)
            {
                CreateManager();
            }
            return _prcm.GetClient();
        }
    }

}