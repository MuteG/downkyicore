using System.Diagnostics;
using System.Net;
using DownKyi.Core.Logging;
using DownKyi.Core.Settings;
using DownKyi.Core.Settings.Models;
using DownKyi.Core.Storage;
using DownKyi.Core.Utils;
using Console = DownKyi.Core.Utils.Debugging.Console;

namespace DownKyi.Core.BiliApi.Login
{
    public static class LoginHelper
    {
        // 本地位置
        private static readonly string _localLoginInfo = StorageManager.GetLogin();

        // 16位密码，ps:密码位数没有限制，可任意设置
        // private const string SECRET_KEY = "EsOat*^y1QR!&0J6";

        /// <summary>
        /// 保存登录的cookies到文件
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool SaveLoginInfoCookies(string url)
        {
            string tempFile = _localLoginInfo + "-" + Guid.NewGuid().ToString("N");
            CookieContainer cookieContainer = ObjectHelper.ParseCookie(url);

            bool isSucceed = ObjectHelper.WriteCookiesToDisk(tempFile, cookieContainer);
            if (isSucceed)
            {
                // 加密密钥，增加机器码
                // var password = SECRET_KEY;

                try
                {
                    File.Copy(tempFile, _localLoginInfo, true);
                    // Encryptor.EncryptFile(tempFile, LOCAL_LOGIN_INFO, password);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("SaveLoginInfoCookies()发生异常: {0}", e);
                    LogManager.Error(e);
                    return false;
                }
            }

            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }

            return isSucceed;
        }


        /// <summary>
        /// 获得登录的cookies
        /// </summary>
        /// <returns></returns>
        public static CookieContainer? GetLoginInfoCookies()
        {
            var tempFile = _localLoginInfo + "-" + Guid.NewGuid().ToString("N");

            if (File.Exists(_localLoginInfo))
            {
                try
                {
                    File.Copy(_localLoginInfo, tempFile, true);
                    // 加密密钥，增加机器码
                    // var password = SECRET_KEY;
                    // Encryptor.DecryptFile(LOCAL_LOGIN_INFO, tempFile, password);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("GetLoginInfoCookies()发生异常: {0}", e);
                    LogManager.Error(e);
                    if (File.Exists(tempFile))
                    {
                        File.Delete(tempFile);
                    }

                    return null;
                }
            }
            else
            {
                return null;
            }

            CookieContainer cookies = ObjectHelper.ReadCookiesFromDisk(tempFile);

            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }

            return cookies;
        }

        /// <summary>
        /// 返回登录信息的cookies的字符串
        /// </summary>
        /// <returns></returns>
        public static string GetLoginInfoCookiesString()
        {
            var cookieContainer = GetLoginInfoCookies();
            if (cookieContainer == null)
            {
                return "";
            }

            var cookies = cookieContainer.GetAllCookies();

            string cookie = string.Empty;
            foreach (var item in cookies)
            {
                cookie += item + ";";
            }

            return cookie.TrimEnd(';');
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <returns></returns>
        public static bool Logout()
        {
            if (File.Exists(_localLoginInfo))
            {
                try
                {
                    File.Delete(_localLoginInfo);

                    SettingsManager.GetInstance().SetUserInfo(new UserInfoSettings
                    {
                        Mid = -1,
                        Name = "",
                        IsLogin = false,
                        IsVip = false
                    });
                    return true;
                }
                catch (IOException e)
                {
                    Debug.WriteLine("Logout()发生异常: {0}", e);
                    LogManager.Error(e);
                    return false;
                }
            }

            return false;
        }
    }
}