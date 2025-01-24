// using DownKyi.Core.Aria2cNet.Server;

using DownKyi.Core.Aria2cNet.Server;

namespace DownKyi.Core.Settings
{
    public partial class SettingsManager
    {
        // 是否开启解除地区限制
        private readonly AllowStatus isLiftingOfRegion = AllowStatus.YES;

        // 启用https
        private readonly AllowStatus useSSL = AllowStatus.YES;

        // UserAgent
        private readonly string userAgent =
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";

        // 下载器
        private readonly Downloader downloader = Downloader.ARIA;

        // 最大同时下载数(任务数)
        private readonly int maxCurrentDownloads = 3;

        // 单文件最大线程数
        private readonly int split = 8;

        // HttpProxy代理
        private readonly AllowStatus isHttpProxy = AllowStatus.NO;
        private readonly string httpProxy = string.Empty;
        private readonly int httpProxyListenPort = 0;

        // Aria服务器token
        private readonly string ariaToken = "downkyi";

        // Aria服务器host
        private readonly string ariaHost = "http://localhost";

        // Aria服务器端口号
        private readonly int ariaListenPort = 6800;

        // Aria日志等级
        private readonly AriaConfigLogLevel ariaLogLevel = AriaConfigLogLevel.INFO;

        // Aria单文件最大线程数
        private readonly int ariaSplit = 5;

        // Aria下载速度限制
        private readonly int ariaMaxOverallDownloadLimit = 0;

        // Aria下载单文件速度限制
        private readonly int ariaMaxDownloadLimit = 0;

        // Aria文件预分配
        private readonly AriaConfigFileAllocation ariaFileAllocation = AriaConfigFileAllocation.NONE;

        // Aria HttpProxy代理
        private readonly AllowStatus isAriaHttpProxy = AllowStatus.NO;
        private readonly string ariaHttpProxy = string.Empty;
        private readonly int ariaHttpProxyListenPort = 0;

        /// <summary>
        /// 获取是否解除地区限制
        /// </summary>
        /// <returns></returns>
        public AllowStatus IsLiftingOfRegion()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.IsLiftingOfRegion == AllowStatus.NONE)
            {
                // 第一次获取，先设置默认值
                IsLiftingOfRegion(isLiftingOfRegion);
                return isLiftingOfRegion;
            }

            return _appSettings.Network.IsLiftingOfRegion;
        }

        /// <summary>
        /// 设置是否解除地区限制
        /// </summary>
        /// <param name="isLiftingOfRegion"></param>
        /// <returns></returns>
        public bool IsLiftingOfRegion(AllowStatus isLiftingOfRegion)
        {
            _appSettings.Network.IsLiftingOfRegion = isLiftingOfRegion;
            return SetSettings();
        }

        /// <summary>
        /// 获取是否启用https
        /// </summary>
        /// <returns></returns>
        public AllowStatus UseSSL()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.UseSSL == AllowStatus.NONE)
            {
                // 第一次获取，先设置默认值
                UseSSL(useSSL);
                return useSSL;
            }

            return _appSettings.Network.UseSSL;
        }

        /// <summary>
        /// 设置是否启用https
        /// </summary>
        /// <param name="useSSL"></param>
        /// <returns></returns>
        public bool UseSSL(AllowStatus useSSL)
        {
            _appSettings.Network.UseSSL = useSSL;
            return SetSettings();
        }

        /// <summary>
        /// 获取UserAgent
        /// </summary>
        /// <returns></returns>
        public string GetUserAgent()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.UserAgent == string.Empty)
            {
                // 第一次获取，先设置默认值
                SetUserAgent(userAgent);
                return userAgent;
            }

            return _appSettings.Network.UserAgent;
        }

        /// <summary>
        /// 设置UserAgent
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        public bool SetUserAgent(string userAgent)
        {
            _appSettings.Network.UserAgent = userAgent;
            return SetSettings();
        }

        /// <summary>
        /// 获取下载器
        /// </summary>
        /// <returns></returns>
        public Downloader GetDownloader()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.Downloader != Downloader.NOT_SET) return _appSettings.Network.Downloader;
            // 第一次获取，先设置默认值
            SetDownloader(downloader);
            return downloader;
        }

        /// <summary>
        /// 设置下载器
        /// </summary>
        /// <param name="downloader"></param>
        /// <returns></returns>
        public bool SetDownloader(Downloader downloader)
        {
            _appSettings.Network.Downloader = downloader;
            return SetSettings();
        }

        /// <summary>
        /// 获取最大同时下载数(任务数)
        /// </summary>
        /// <returns></returns>
        public int GetMaxCurrentDownloads()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.MaxCurrentDownloads != -1) return _appSettings.Network.MaxCurrentDownloads;
            // 第一次获取，先设置默认值
            SetMaxCurrentDownloads(maxCurrentDownloads);
            return maxCurrentDownloads;
        }

        /// <summary>
        /// 设置最大同时下载数(任务数)
        /// </summary>
        /// <param name="maxCurrentDownloads"></param>
        /// <returns></returns>
        public bool SetMaxCurrentDownloads(int maxCurrentDownloads)
        {
            _appSettings.Network.MaxCurrentDownloads = maxCurrentDownloads;
            return SetSettings();
        }

        /// <summary>
        /// 获取单文件最大线程数
        /// </summary>
        /// <returns></returns>
        public int GetSplit()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.Split != -1) return _appSettings.Network.Split;
            // 第一次获取，先设置默认值
            SetSplit(split);
            return split;
        }

        /// <summary>
        /// 设置单文件最大线程数
        /// </summary>
        /// <param name="split"></param>
        /// <returns></returns>
        public bool SetSplit(int split)
        {
            _appSettings.Network.Split = split;
            return SetSettings();
        }

        /// <summary>
        /// 获取是否开启Http代理
        /// </summary>
        /// <returns></returns>
        public AllowStatus IsHttpProxy()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.IsHttpProxy != AllowStatus.NONE) return _appSettings.Network.IsHttpProxy;
            // 第一次获取，先设置默认值
            IsHttpProxy(isHttpProxy);
            return isHttpProxy;
        }

        /// <summary>
        /// 设置是否开启Http代理
        /// </summary>
        /// <param name="isHttpProxy"></param>
        /// <returns></returns>
        public bool IsHttpProxy(AllowStatus isHttpProxy)
        {
            _appSettings.Network.IsHttpProxy = isHttpProxy;
            return SetSettings();
        }

        /// <summary>
        /// 获取Http代理的地址
        /// </summary>
        /// <returns></returns>
        public string GetHttpProxy()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.HttpProxy != null) return _appSettings.Network.HttpProxy;
            // 第一次获取，先设置默认值
            SetHttpProxy(httpProxy);
            return httpProxy;
        }

        /// <summary>
        /// 设置Aria的http代理的地址
        /// </summary>
        /// <param name="httpProxy"></param>
        /// <returns></returns>
        public bool SetHttpProxy(string httpProxy)
        {
            _appSettings.Network.HttpProxy = httpProxy;
            return SetSettings();
        }

        /// <summary>
        /// 获取Http代理的端口
        /// </summary>
        /// <returns></returns>
        public int GetHttpProxyListenPort()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.HttpProxyListenPort != -1) return _appSettings.Network.HttpProxyListenPort;
            // 第一次获取，先设置默认值
            SetHttpProxyListenPort(httpProxyListenPort);
            return httpProxyListenPort;
        }

        /// <summary>
        /// 设置Http代理的端口
        /// </summary>
        /// <param name="httpProxyListenPort"></param>
        /// <returns></returns>
        public bool SetHttpProxyListenPort(int httpProxyListenPort)
        {
            _appSettings.Network.HttpProxyListenPort = httpProxyListenPort;
            return SetSettings();
        }

        /// <summary>
        /// 获取Aria服务器的token
        /// </summary>
        /// <returns></returns>
        public string GetAriaToken()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.AriaToken == null)
            {
                // 第一次获取，先设置默认值
                SetHttpProxy(ariaToken);
                return ariaToken;
            }

            return _appSettings.Network.AriaToken;
        }

        /// <summary>
        /// 设置Aria服务器的token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool SetAriaToken(string token)
        {
            _appSettings.Network.AriaToken = token;
            return SetSettings();
        }

        /// <summary>
        /// 获取Aria服务器的host
        /// </summary>
        /// <returns></returns>
        public string GetAriaHost()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.AriaHost == null)
            {
                // 第一次获取，先设置默认值
                SetHttpProxy(ariaHost);
                return ariaHost;
            }

            return _appSettings.Network.AriaHost;
        }

        /// <summary>
        /// 设置Aria服务器的host
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public bool SetAriaHost(string host)
        {
            _appSettings.Network.AriaHost = host;
            return SetSettings();
        }

        /// <summary>
        /// 获取Aria服务器的端口号
        /// </summary>
        /// <returns></returns>
        public int GetAriaListenPort()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.AriaListenPort == -1)
            {
                // 第一次获取，先设置默认值
                SetAriaListenPort(ariaListenPort);
                return ariaListenPort;
            }

            return _appSettings.Network.AriaListenPort;
        }

        /// <summary>
        /// 设置Aria服务器的端口号
        /// </summary>
        /// <param name="ariaListenPort"></param>
        /// <returns></returns>
        public bool SetAriaListenPort(int ariaListenPort)
        {
            _appSettings.Network.AriaListenPort = ariaListenPort;
            return SetSettings();
        }

        /// <summary>
        /// 获取Aria日志等级
        /// </summary>
        /// <returns></returns>
        public AriaConfigLogLevel GetAriaLogLevel()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.AriaLogLevel == AriaConfigLogLevel.NOT_SET)
            {
                // 第一次获取，先设置默认值
                SetAriaLogLevel(ariaLogLevel);
                return ariaLogLevel;
            }

            return _appSettings.Network.AriaLogLevel;
        }

        /// <summary>
        /// 设置Aria日志等级
        /// </summary>
        /// <param name="ariaLogLevel"></param>
        /// <returns></returns>
        public bool SetAriaLogLevel(AriaConfigLogLevel ariaLogLevel)
        {
            _appSettings.Network.AriaLogLevel = ariaLogLevel;
            return SetSettings();
        }

        /// <summary>
        /// 获取Aria单文件最大线程数
        /// </summary>
        /// <returns></returns>
        public int GetAriaSplit()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.AriaSplit == -1)
            {
                // 第一次获取，先设置默认值
                SetAriaSplit(ariaSplit);
                return ariaSplit;
            }

            return _appSettings.Network.AriaSplit;
        }

        /// <summary>
        /// 设置Aria单文件最大线程数
        /// </summary>
        /// <param name="ariaSplit"></param>
        /// <returns></returns>
        public bool SetAriaSplit(int ariaSplit)
        {
            _appSettings.Network.AriaSplit = ariaSplit;
            return SetSettings();
        }

        /// <summary>
        /// 获取Aria下载速度限制
        /// </summary>
        /// <returns></returns>
        public int GetAriaMaxOverallDownloadLimit()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.AriaMaxOverallDownloadLimit == -1)
            {
                // 第一次获取，先设置默认值
                SetAriaMaxOverallDownloadLimit(ariaMaxOverallDownloadLimit);
                return ariaMaxOverallDownloadLimit;
            }

            return _appSettings.Network.AriaMaxOverallDownloadLimit;
        }

        /// <summary>
        /// 设置Aria下载速度限制
        /// </summary>
        /// <param name="ariaMaxOverallDownloadLimit"></param>
        /// <returns></returns>
        public bool SetAriaMaxOverallDownloadLimit(int ariaMaxOverallDownloadLimit)
        {
            _appSettings.Network.AriaMaxOverallDownloadLimit = ariaMaxOverallDownloadLimit;
            return SetSettings();
        }

        /// <summary>
        /// 获取Aria下载单文件速度限制
        /// </summary>
        /// <returns></returns>
        public int GetAriaMaxDownloadLimit()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.AriaMaxDownloadLimit == -1)
            {
                // 第一次获取，先设置默认值
                SetAriaMaxDownloadLimit(ariaMaxDownloadLimit);
                return ariaMaxDownloadLimit;
            }

            return _appSettings.Network.AriaMaxDownloadLimit;
        }

        /// <summary>
        /// 设置Aria下载单文件速度限制
        /// </summary>
        /// <param name="ariaMaxDownloadLimit"></param>
        /// <returns></returns>
        public bool SetAriaMaxDownloadLimit(int ariaMaxDownloadLimit)
        {
            _appSettings.Network.AriaMaxDownloadLimit = ariaMaxDownloadLimit;
            return SetSettings();
        }

        /// <summary>
        /// 获取Aria文件预分配
        /// </summary>
        /// <returns></returns>
        public AriaConfigFileAllocation GetAriaFileAllocation()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.AriaFileAllocation == AriaConfigFileAllocation.NOT_SET)
            {
                // 第一次获取，先设置默认值
                SetAriaFileAllocation(ariaFileAllocation);
                return ariaFileAllocation;
            }

            return _appSettings.Network.AriaFileAllocation;
        }

        /// <summary>
        /// 设置Aria文件预分配
        /// </summary>
        /// <param name="ariaFileAllocation"></param>
        /// <returns></returns>
        public bool SetAriaFileAllocation(AriaConfigFileAllocation ariaFileAllocation)
        {
            _appSettings.Network.AriaFileAllocation = ariaFileAllocation;
            return SetSettings();
        }

        /// <summary>
        /// 获取是否开启Aria http代理
        /// </summary>
        /// <returns></returns>
        public AllowStatus IsAriaHttpProxy()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.IsAriaHttpProxy == AllowStatus.NONE)
            {
                // 第一次获取，先设置默认值
                IsAriaHttpProxy(isAriaHttpProxy);
                return isAriaHttpProxy;
            }

            return _appSettings.Network.IsAriaHttpProxy;
        }

        /// <summary>
        /// 设置是否开启Aria http代理
        /// </summary>
        /// <param name="isAriaHttpProxy"></param>
        /// <returns></returns>
        public bool IsAriaHttpProxy(AllowStatus isAriaHttpProxy)
        {
            _appSettings.Network.IsAriaHttpProxy = isAriaHttpProxy;
            return SetSettings();
        }

        /// <summary>
        /// 获取Aria的http代理的地址
        /// </summary>
        /// <returns></returns>
        public string GetAriaHttpProxy()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.AriaHttpProxy == null)
            {
                // 第一次获取，先设置默认值
                SetAriaHttpProxy(ariaHttpProxy);
                return ariaHttpProxy;
            }

            return _appSettings.Network.AriaHttpProxy;
        }

        /// <summary>
        /// 设置Aria的http代理的地址
        /// </summary>
        /// <param name="ariaHttpProxy"></param>
        /// <returns></returns>
        public bool SetAriaHttpProxy(string ariaHttpProxy)
        {
            _appSettings.Network.AriaHttpProxy = ariaHttpProxy;
            return SetSettings();
        }

        /// <summary>
        /// 获取Aria的http代理的端口
        /// </summary>
        /// <returns></returns>
        public int GetAriaHttpProxyListenPort()
        {
            _appSettings = GetSettings();
            if (_appSettings.Network.AriaHttpProxyListenPort == -1)
            {
                // 第一次获取，先设置默认值
                SetAriaHttpProxyListenPort(ariaHttpProxyListenPort);
                return ariaHttpProxyListenPort;
            }

            return _appSettings.Network.AriaHttpProxyListenPort;
        }

        /// <summary>
        /// 设置Aria的http代理的端口
        /// </summary>
        /// <param name="ariaHttpProxyListenPort"></param>
        /// <returns></returns>
        public bool SetAriaHttpProxyListenPort(int ariaHttpProxyListenPort)
        {
            _appSettings.Network.AriaHttpProxyListenPort = ariaHttpProxyListenPort;
            return SetSettings();
        }
    }
}