using System.Net;
using DownKyi.Core.Logging;
using MessagePack;
using Console = DownKyi.Core.Utils.Debugging.Console;

namespace DownKyi.Core.Utils;

public static class ObjectHelper
{
    /// <summary>
    /// 解析二维码登录返回的url，用于设置cookie
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static CookieContainer ParseCookie(string url)
    {
        var cookieContainer = new CookieContainer();

        if (url is null or "")
        {
            return cookieContainer;
        }

        var strList = url.Split('?');
        if (strList.Length < 2)
        {
            return cookieContainer;
        }

        var strList2 = strList[1].Split('&');
        if (strList2.Length == 0)
        {
            return cookieContainer;
        }

        // 获取expires
        var expires = strList2.FirstOrDefault(it => it.Contains("Expires"))?.Split('=')[1] ?? string.Empty;
        var dateTime = DateTime.Now.AddSeconds(int.Parse(expires));

        foreach (var item in strList2)
        {
            var strList3 = item.Split('=');
            if (strList3.Length < 2)
            {
                continue;
            }

            var name = strList3[0];
            var value = strList3[1];

            // 不需要
            if (name == "Expires" || name == "gourl")
            {
                continue;
            }

            // 添加cookie
            cookieContainer.Add(
                new Cookie(name, value.Replace(",", "%2c"), "/", ".bilibili.com") { Expires = dateTime });
            Console.PrintLine(name + ": " + value + "\t" + cookieContainer.Count);
        }

        return cookieContainer;
    }

    /// <summary>
    /// 将CookieContainer中的所有的Cookie读出来
    /// </summary>
    /// <param name="cc"></param>
    /// <returns></returns>
    public static List<Cookie> GetAllCookies(CookieContainer cc)
    {
        return cc.GetAllCookies().ToList();
    }

    /// <summary>
    /// 写入cookies到磁盘
    /// </summary>
    /// <param name="file"></param>
    /// <param name="cookieJar"></param>
    /// <returns></returns>
    public static bool WriteCookiesToDisk(string file, CookieContainer cookieJar)
    {
        return WriteObjectToDisk(file, cookieJar);
    }

    /// <summary>
    /// 从磁盘读取cookie
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static CookieContainer ReadCookiesFromDisk(string file)
    {
        return ReadObjectFromDisk<CookieContainer>(file);
    }

    /// <summary>
    /// 写入序列化对象到磁盘
    /// </summary>
    /// <param name="file"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool WriteObjectToDisk<T>(string file, T obj)
    {
        try
        {
            using Stream stream = File.Create(file);
            Console.PrintLine("Writing object to disk... ");

            MessagePackSerializer.Serialize(stream, obj, MessagePack.Resolvers.ContractlessStandardResolver.Options);

            Console.PrintLine("Done.");
            return true;
        }
        catch (IOException e)
        {
            Console.PrintLine("WriteObjectToDisk()发生IO异常: {0}", e);
            LogManager.Error(e);
            return false;
        }
        catch (Exception e)
        {
            Console.PrintLine("WriteObjectToDisk()发生异常: {0}", e);
            LogManager.Error(e);
            return false;
        }
    }

    /// <summary>
    /// 从磁盘读取序列化对象
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static T ReadObjectFromDisk<T>(string file) where T : class
    {
        try
        {
            using Stream stream = File.Open(file, FileMode.Open);
            Console.PrintLine("Reading object from disk... ");
            return MessagePackSerializer.Deserialize<T>(stream, MessagePack.Resolvers.ContractlessStandardResolver.Options);
        }
        catch (IOException e)
        {
            Console.PrintLine("ReadObjectFromDisk()发生IO异常: {0}", e);
            LogManager.Error(e);
            return null;
        }
        catch (Exception e)
        {
            Console.PrintLine("ReadObjectFromDisk()发生异常: {0}", e);
            LogManager.Error(e);
            return null;
        }
    }
}