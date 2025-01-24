﻿using System.Diagnostics;
using DownKyi.Core.Logging;
using Console = DownKyi.Core.Utils.Debugging.Console;

namespace DownKyi.Core.Utils;

public static class HardDisk
{
    /// <summary>
    /// 获取指定驱动器的空间总大小
    /// </summary>
    /// <param name="hardDiskName">只需输入代表驱动器的字母即可</param>
    /// <returns></returns>
    public static long GetHardDiskSpace(string hardDiskName)
    {
        long totalSize = 0;

        try
        {
            hardDiskName = $"{hardDiskName}:\\";
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                if (drive.Name == hardDiskName)
                {
                    totalSize = drive.TotalSize;
                }
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine("GetHardDiskSpace()发生异常: {0}", e);
            LogManager.Error("HardDisk", e);
        }

        return totalSize;
    }

    /// <summary>
    /// 获取指定驱动器的剩余空间总大小
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns></returns>
    /*public static long GetHardDiskFreeSpace(string hardDiskName)
    {
        long freeSpace = 0;
        try
        {
            hardDiskName = $"{hardDiskName}:\\";
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                if (drive.Name == hardDiskName)
                {
                    freeSpace = drive.TotalFreeSpace;
                }
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine("GetHardDiskFreeSpace()发生异常: {0}", e);
            LogManager.Error("HardDisk", e);
        }

        return freeSpace;
    }*/
    public static long GetHardDiskFreeSpace(string path)
    {
        long freeSpace = 0;
        try
        {
            var driveInfo = new DriveInfo(path);
            // hardDiskName = $"{path}:\\";
            freeSpace = driveInfo.TotalFreeSpace;
        }
        catch (Exception e)
        {
            Debug.WriteLine("GetHardDiskFreeSpace()发生异常: {0}", e);
            LogManager.Error("HardDisk", e);
        }

        return freeSpace;
    }
}