using DownKyi.Core.FileName;
using DownKyi.Core.Settings.Models;
using DownKyi.Core.Storage;

namespace DownKyi.Core.Settings;

public partial class SettingsManager
{
    // 设置优先下载的视频编码
    private readonly int videoCodecs = 7;

    // 设置优先下载画质
    private readonly int quality = 120;

    // 设置优先下载音质
    private readonly int audioQuality = 30280;
    
    // 设置首选视频解析方式
    private const int VideoParseType = 1;

    // 是否下载flv视频后转码为mp4
    private readonly AllowStatus isTranscodingFlvToMp4 = AllowStatus.YES;
    
    // 是否下载aac音频后转码为mp3
    private readonly AllowStatus isTranscodingAacToMp3 = AllowStatus.YES;

    // 默认下载目录
    private readonly string saveVideoRootPath = StorageManager.GetMedia();

    // 历史下载目录
    private readonly List<string> historyVideoRootPaths = new();

    // 是否使用默认下载目录，如果是，则每次点击下载选中项时不再询问下载目录
    private readonly AllowStatus isUseSaveVideoRootPath = AllowStatus.NO;

    // 下载内容
    private readonly VideoContentSettings videoContent = new();

    // 文件命名格式
    private readonly List<FileNamePart> fileNameParts = new()
    {
        FileNamePart.MAIN_TITLE,
        FileNamePart.SLASH,
        FileNamePart.SECTION,
        FileNamePart.SLASH,
        FileNamePart.ORDER,
        FileNamePart.HYPHEN,
        FileNamePart.PAGE_TITLE,
        FileNamePart.HYPHEN,
        FileNamePart.VIDEO_QUALITY,
        FileNamePart.HYPHEN,
        FileNamePart.VIDEO_CODEC,
    };

    // 文件命名中的时间格式
    private readonly string fileNamePartTimeFormat = "yyyy-MM-dd";

    // 文件命名中的序号格式
    private readonly OrderFormat orderFormat = OrderFormat.NATURAL;

    /// <summary>
    /// 获取优先下载的视频编码
    /// </summary>
    /// <returns></returns>
    public int GetVideoCodecs()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.VideoCodecs == -1)
        {
            // 第一次获取，先设置默认值
            SetVideoCodecs(videoCodecs);
            return videoCodecs;
        }

        return _appSettings.Video.VideoCodecs;
    }

    /// <summary>
    /// 设置优先下载的视频编码
    /// </summary>
    /// <param name="videoCodecs"></param>
    /// <returns></returns>
    public bool SetVideoCodecs(int videoCodecs)
    {
        _appSettings.Video.VideoCodecs = videoCodecs;
        return SetSettings();
    }

    /// <summary>
    /// 获取优先下载画质
    /// </summary>
    /// <returns></returns>
    public int GetQuality()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.Quality == -1)
        {
            // 第一次获取，先设置默认值
            SetQuality(quality);
            return quality;
        }

        return _appSettings.Video.Quality;
    }

    /// <summary>
    /// 设置优先下载画质
    /// </summary>
    /// <param name="quality"></param>
    /// <returns></returns>
    public bool SetQuality(int quality)
    {
        _appSettings.Video.Quality = quality;
        return SetSettings();
    }

    /// <summary>
    /// 获取优先下载音质
    /// </summary>
    /// <returns></returns>
    public int GetAudioQuality()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.AudioQuality == -1)
        {
            // 第一次获取，先设置默认值
            SetAudioQuality(audioQuality);
            return audioQuality;
        }

        return _appSettings.Video.AudioQuality;
    }

    /// <summary>
    /// 设置优先下载音质
    /// </summary>
    /// <param name="quality"></param>
    /// <returns></returns>
    public bool SetAudioQuality(int quality)
    {
        _appSettings.Video.AudioQuality = quality;
        return SetSettings();
    }
    
    /// <summary>
    /// 获取首选视频解析方式
    /// </summary>
    /// <returns></returns>
    public int GetVideoParseType()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.VideoParseType == null)
        {
            // 第一次获取，先设置默认值
            SetVideoParseType(VideoParseType);
            return VideoParseType;
        }

        return _appSettings.Video.VideoParseType;
    }
    
    /// <summary>
    /// 设置首选视频解析方式
    /// </summary>
    /// <param name="videoParseType"></param>
    /// <returns></returns>
    public bool SetVideoParseType(int videoParseType)
    {
        _appSettings.Video.VideoParseType = videoParseType;
        return SetSettings();
    }

    /// <summary>
    /// 获取是否下载flv视频后转码为mp4
    /// </summary>
    /// <returns></returns>
    public AllowStatus IsTranscodingFlvToMp4()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.IsTranscodingFlvToMp4 == AllowStatus.NONE)
        {
            // 第一次获取，先设置默认值
            IsTranscodingFlvToMp4(isTranscodingFlvToMp4);
            return isTranscodingFlvToMp4;
        }

        return _appSettings.Video.IsTranscodingFlvToMp4;
    }

    /// <summary>
    /// 设置是否下载flv视频后转码为mp4
    /// </summary>
    /// <param name="isTranscodingFlvToMp4"></param>
    /// <returns></returns>
    public bool IsTranscodingFlvToMp4(AllowStatus isTranscodingFlvToMp4)
    {
        _appSettings.Video.IsTranscodingFlvToMp4 = isTranscodingFlvToMp4;
        return SetSettings();
    }
    
    /// <summary>
    /// 获取是否下载aac音频后转码为mp3
    /// </summary>
    /// <returns></returns>
    public AllowStatus IsTranscodingAacToMp3()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.IsTranscodingAacToMp3 == AllowStatus.NONE)
        {
            // 第一次获取，先设置默认值
            IsTranscodingAacToMp3(isTranscodingAacToMp3);
            return isTranscodingAacToMp3;
        }

        return _appSettings.Video.IsTranscodingAacToMp3;
    }
    
    /// <summary>
    /// 设置是否下载aac音频后转码为mp3
    /// </summary>
    /// <param name="isTranscodingAacToMp3"></param>
    /// <returns></returns>
    public bool IsTranscodingAacToMp3(AllowStatus isTranscodingAacToMp3)
    {
        _appSettings.Video.IsTranscodingAacToMp3 = isTranscodingAacToMp3;
        return SetSettings();
    }

    /// <summary>
    /// 获取下载目录
    /// </summary>
    /// <returns></returns>
    public string GetSaveVideoRootPath()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.SaveVideoRootPath == null)
        {
            // 第一次获取，先设置默认值
            SetSaveVideoRootPath(saveVideoRootPath);
            return saveVideoRootPath;
        }

        return _appSettings.Video.SaveVideoRootPath;
    }

    /// <summary>
    /// 设置下载目录
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public bool SetSaveVideoRootPath(string path)
    {
        _appSettings.Video.SaveVideoRootPath = path;
        return SetSettings();
    }

    /// <summary>
    /// 获取历史下载目录
    /// </summary>
    /// <returns></returns>
    public List<string> GetHistoryVideoRootPaths()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.HistoryVideoRootPaths == null)
        {
            // 第一次获取，先设置默认值
            SetHistoryVideoRootPaths(historyVideoRootPaths);
            return historyVideoRootPaths;
        }

        return _appSettings.Video.HistoryVideoRootPaths;
    }

    /// <summary>
    /// 设置历史下载目录
    /// </summary>
    /// <param name="historyPaths"></param>
    /// <returns></returns>
    public bool SetHistoryVideoRootPaths(List<string> historyPaths)
    {
        _appSettings.Video.HistoryVideoRootPaths = historyPaths;
        return SetSettings();
    }

    /// <summary>
    /// 获取是否使用默认下载目录
    /// </summary>
    /// <returns></returns>
    public AllowStatus IsUseSaveVideoRootPath()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.IsUseSaveVideoRootPath == AllowStatus.NONE)
        {
            // 第一次获取，先设置默认值
            IsUseSaveVideoRootPath(isUseSaveVideoRootPath);
            return isUseSaveVideoRootPath;
        }

        return _appSettings.Video.IsUseSaveVideoRootPath;
    }

    /// <summary>
    /// 设置是否使用默认下载目录
    /// </summary>
    /// <param name="isUseSaveVideoRootPath"></param>
    /// <returns></returns>
    public bool IsUseSaveVideoRootPath(AllowStatus isUseSaveVideoRootPath)
    {
        _appSettings.Video.IsUseSaveVideoRootPath = isUseSaveVideoRootPath;
        return SetSettings();
    }

    /// <summary>
    /// 获取下载内容
    /// </summary>
    /// <returns></returns>
    public VideoContentSettings GetVideoContent()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.VideoContent == null)
        {
            // 第一次获取，先设置默认值
            SetVideoContent(videoContent);
            return videoContent;
        }

        return _appSettings.Video.VideoContent;
    }

    /// <summary>
    /// 设置下载内容
    /// </summary>
    /// <param name="videoContent"></param>
    /// <returns></returns>
    public bool SetVideoContent(VideoContentSettings videoContent)
    {
        _appSettings.Video.VideoContent = videoContent;
        return SetSettings();
    }

    /// <summary>
    /// 获取文件命名格式
    /// </summary>
    /// <returns></returns>
    public List<FileNamePart> GetFileNameParts()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.FileNameParts == null || _appSettings.Video.FileNameParts.Count == 0)
        {
            // 第一次获取，先设置默认值
            SetFileNameParts(fileNameParts);
            return fileNameParts;
        }

        return _appSettings.Video.FileNameParts;
    }

    /// <summary>
    /// 设置文件命名格式
    /// </summary>
    /// <param name="historyPaths"></param>
    /// <returns></returns>
    public bool SetFileNameParts(List<FileNamePart> fileNameParts)
    {
        _appSettings.Video.FileNameParts = fileNameParts;
        return SetSettings();
    }

    /// <summary>
    /// 获取文件命名中的时间格式
    /// </summary>
    /// <returns></returns>
    public string GetFileNamePartTimeFormat()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.FileNamePartTimeFormat == null ||
            _appSettings.Video.FileNamePartTimeFormat == string.Empty)
        {
            // 第一次获取，先设置默认值
            SetFileNamePartTimeFormat(fileNamePartTimeFormat);
            return fileNamePartTimeFormat;
        }

        return _appSettings.Video.FileNamePartTimeFormat;
    }

    /// <summary>
    /// 设置文件命名中的时间格式
    /// </summary>
    /// <param name="fileNamePartTimeFormat"></param>
    /// <returns></returns>
    public bool SetFileNamePartTimeFormat(string fileNamePartTimeFormat)
    {
        _appSettings.Video.FileNamePartTimeFormat = fileNamePartTimeFormat;
        return SetSettings();
    }

    /// <summary>
    /// 获取文件命名中的序号格式
    /// </summary>
    /// <returns></returns>
    public OrderFormat GetOrderFormat()
    {
        _appSettings = GetSettings();
        if (_appSettings.Video.OrderFormat == OrderFormat.NOT_SET)
        {
            // 第一次获取，先设置默认值
            SetOrderFormat(orderFormat);
            return orderFormat;
        }

        return _appSettings.Video.OrderFormat;
    }

    /// <summary>
    /// 设置文件命名中的序号格式
    /// </summary>
    /// <param name="orderFormat"></param>
    /// <returns></returns>
    public bool SetOrderFormat(OrderFormat orderFormat)
    {
        _appSettings.Video.OrderFormat = orderFormat;
        return SetSettings();
    }
}