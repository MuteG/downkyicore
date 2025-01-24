namespace DownKyi.Core.Settings;

public partial class SettingsManager
{
    // 是否屏蔽顶部弹幕
    private readonly AllowStatus danmakuTopFilter = AllowStatus.NO;

    // 是否屏蔽底部弹幕
    private readonly AllowStatus danmakuBottomFilter = AllowStatus.NO;

    // 是否屏蔽滚动弹幕
    private readonly AllowStatus danmakuScrollFilter = AllowStatus.NO;

    // 是否自定义分辨率
    private readonly AllowStatus isCustomDanmakuResolution = AllowStatus.NO;

    // 分辨率-宽
    private readonly int danmakuScreenWidth = 1920;

    // 分辨率-高
    private readonly int danmakuScreenHeight = 1080;

    // 弹幕字体
    private readonly string danmakuFontName = "黑体";

    // 弹幕字体大小
    private readonly int danmakuFontSize = 50;

    // 弹幕限制行数
    private readonly int danmakuLineCount = 0;

    // 弹幕布局算法
    private readonly DanmakuLayoutAlgorithm danmakuLayoutAlgorithm = DanmakuLayoutAlgorithm.SYNC;


    /// <summary>
    /// 获取是否屏蔽顶部弹幕
    /// </summary>
    /// <returns></returns>
    public AllowStatus GetDanmakuTopFilter()
    {
        _appSettings = GetSettings();
        if (_appSettings.Danmaku.DanmakuTopFilter == AllowStatus.NONE)
        {
            // 第一次获取，先设置默认值
            SetDanmakuTopFilter(danmakuTopFilter);
            return danmakuTopFilter;
        }

        return _appSettings.Danmaku.DanmakuTopFilter;
    }

    /// <summary>
    /// 设置是否屏蔽顶部弹幕
    /// </summary>
    /// <param name="danmakuFilter"></param>
    /// <returns></returns>
    public bool SetDanmakuTopFilter(AllowStatus danmakuFilter)
    {
        _appSettings.Danmaku.DanmakuTopFilter = danmakuFilter;
        return SetSettings();
    }

    /// <summary>
    /// 获取是否屏蔽底部弹幕
    /// </summary>
    /// <returns></returns>
    public AllowStatus GetDanmakuBottomFilter()
    {
        _appSettings = GetSettings();
        if (_appSettings.Danmaku.DanmakuBottomFilter == AllowStatus.NONE)
        {
            // 第一次获取，先设置默认值
            SetDanmakuBottomFilter(danmakuBottomFilter);
            return danmakuBottomFilter;
        }

        return _appSettings.Danmaku.DanmakuBottomFilter;
    }

    /// <summary>
    /// 设置是否屏蔽底部弹幕
    /// </summary>
    /// <param name="danmakuFilter"></param>
    /// <returns></returns>
    public bool SetDanmakuBottomFilter(AllowStatus danmakuFilter)
    {
        _appSettings.Danmaku.DanmakuBottomFilter = danmakuFilter;
        return SetSettings();
    }

    /// <summary>
    /// 获取是否屏蔽滚动弹幕
    /// </summary>
    /// <returns></returns>
    public AllowStatus GetDanmakuScrollFilter()
    {
        _appSettings = GetSettings();
        if (_appSettings.Danmaku.DanmakuScrollFilter == AllowStatus.NONE)
        {
            // 第一次获取，先设置默认值
            SetDanmakuScrollFilter(danmakuScrollFilter);
            return danmakuScrollFilter;
        }

        return _appSettings.Danmaku.DanmakuScrollFilter;
    }

    /// <summary>
    /// 设置是否屏蔽滚动弹幕
    /// </summary>
    /// <param name="danmakuFilter"></param>
    /// <returns></returns>
    public bool SetDanmakuScrollFilter(AllowStatus danmakuFilter)
    {
        _appSettings.Danmaku.DanmakuScrollFilter = danmakuFilter;
        return SetSettings();
    }

    /// <summary>
    /// 获取是否自定义分辨率
    /// </summary>
    /// <returns></returns>
    public AllowStatus IsCustomDanmakuResolution()
    {
        _appSettings = GetSettings();
        if (_appSettings.Danmaku.IsCustomDanmakuResolution == AllowStatus.NONE)
        {
            // 第一次获取，先设置默认值
            IsCustomDanmakuResolution(isCustomDanmakuResolution);
            return isCustomDanmakuResolution;
        }

        return _appSettings.Danmaku.IsCustomDanmakuResolution;
    }

    /// <summary>
    /// 设置是否自定义分辨率
    /// </summary>
    /// <param name="isCustomResolution"></param>
    /// <returns></returns>
    public bool IsCustomDanmakuResolution(AllowStatus isCustomResolution)
    {
        _appSettings.Danmaku.IsCustomDanmakuResolution = isCustomResolution;
        return SetSettings();
    }

    /// <summary>
    /// 获取分辨率-宽
    /// </summary>
    /// <returns></returns>
    public int GetDanmakuScreenWidth()
    {
        _appSettings = GetSettings();
        if (_appSettings.Danmaku.DanmakuScreenWidth == -1)
        {
            // 第一次获取，先设置默认值
            SetDanmakuScreenWidth(danmakuScreenWidth);
            return danmakuScreenWidth;
        }

        return _appSettings.Danmaku.DanmakuScreenWidth;
    }

    /// <summary>
    /// 设置分辨率-宽
    /// </summary>
    /// <param name="screenWidth"></param>
    /// <returns></returns>
    public bool SetDanmakuScreenWidth(int screenWidth)
    {
        _appSettings.Danmaku.DanmakuScreenWidth = screenWidth;
        return SetSettings();
    }

    /// <summary>
    /// 获取分辨率-高
    /// </summary>
    /// <returns></returns>
    public int GetDanmakuScreenHeight()
    {
        _appSettings = GetSettings();
        if (_appSettings.Danmaku.DanmakuScreenHeight == -1)
        {
            // 第一次获取，先设置默认值
            SetDanmakuScreenHeight(danmakuScreenHeight);
            return danmakuScreenHeight;
        }

        return _appSettings.Danmaku.DanmakuScreenHeight;
    }

    /// <summary>
    /// 设置分辨率-高
    /// </summary>
    /// <param name="screenHeight"></param>
    /// <returns></returns>
    public bool SetDanmakuScreenHeight(int screenHeight)
    {
        _appSettings.Danmaku.DanmakuScreenHeight = screenHeight;
        return SetSettings();
    }

    /// <summary>
    /// 获取弹幕字体
    /// </summary>
    /// <returns></returns>
    public string GetDanmakuFontName()
    {
        _appSettings = GetSettings();
        if (_appSettings.Danmaku.DanmakuFontName == null)
        {
            // 第一次获取，先设置默认值
            SetDanmakuFontName(danmakuFontName);
            return danmakuFontName;
        }

        return _appSettings.Danmaku.DanmakuFontName;
    }

    /// <summary>
    /// 设置弹幕字体
    /// </summary>
    /// <param name="danmakuFontName"></param>
    /// <returns></returns>
    public bool SetDanmakuFontName(string danmakuFontName)
    {
        _appSettings.Danmaku.DanmakuFontName = danmakuFontName;
        return SetSettings();
    }

    /// <summary>
    /// 获取弹幕字体大小
    /// </summary>
    /// <returns></returns>
    public int GetDanmakuFontSize()
    {
        _appSettings = GetSettings();
        if (_appSettings.Danmaku.DanmakuFontSize == -1)
        {
            // 第一次获取，先设置默认值
            SetDanmakuFontSize(danmakuFontSize);
            return danmakuFontSize;
        }

        return _appSettings.Danmaku.DanmakuFontSize;
    }

    /// <summary>
    /// 设置弹幕字体大小
    /// </summary>
    /// <param name="danmakuFontSize"></param>
    /// <returns></returns>
    public bool SetDanmakuFontSize(int danmakuFontSize)
    {
        _appSettings.Danmaku.DanmakuFontSize = danmakuFontSize;
        return SetSettings();
    }

    /// <summary>
    /// 获取弹幕限制行数
    /// </summary>
    /// <returns></returns>
    public int GetDanmakuLineCount()
    {
        _appSettings = GetSettings();
        if (_appSettings.Danmaku.DanmakuLineCount == -1)
        {
            // 第一次获取，先设置默认值
            SetDanmakuLineCount(danmakuLineCount);
            return danmakuLineCount;
        }

        return _appSettings.Danmaku.DanmakuLineCount;
    }

    /// <summary>
    /// 设置弹幕限制行数
    /// </summary>
    /// <param name="danmakuLineCount"></param>
    /// <returns></returns>
    public bool SetDanmakuLineCount(int danmakuLineCount)
    {
        _appSettings.Danmaku.DanmakuLineCount = danmakuLineCount;
        return SetSettings();
    }

    /// <summary>
    /// 获取弹幕布局算法
    /// </summary>
    /// <returns></returns>
    public DanmakuLayoutAlgorithm GetDanmakuLayoutAlgorithm()
    {
        _appSettings = GetSettings();
        if (_appSettings.Danmaku.DanmakuLayoutAlgorithm == DanmakuLayoutAlgorithm.NONE)
        {
            // 第一次获取，先设置默认值
            SetDanmakuLayoutAlgorithm(danmakuLayoutAlgorithm);
            return danmakuLayoutAlgorithm;
        }

        return _appSettings.Danmaku.DanmakuLayoutAlgorithm;
    }

    /// <summary>
    /// 设置弹幕布局算法
    /// </summary>
    /// <param name="danmakuLayoutAlgorithm"></param>
    /// <returns></returns>
    public bool SetDanmakuLayoutAlgorithm(DanmakuLayoutAlgorithm danmakuLayoutAlgorithm)
    {
        _appSettings.Danmaku.DanmakuLayoutAlgorithm = danmakuLayoutAlgorithm;
        return SetSettings();
    }
}