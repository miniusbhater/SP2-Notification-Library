using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using BepInEx;
using HarmonyLib.Tools;
using UnityEngine;

namespace Notification
{
    internal class CheckForUpdates
    {
        // took this code from SierraOSHelper (something i made) https://github.com/miniusbhater/SierraOSHelper/blob/main/SierraOSHelper/Log.cs
        public static async void CheckForUpdate()
        {
            string current = PluginInfo.Version;
            try
            {
                string gistUrl = "https://gist.githubusercontent.com/miniusbhater/75c60eb25b08aae5625093718569f10d/raw/5e9ce6e97d7f83d4b750362ee8924e40f4b82b66/SP2-Notification-Library.txt";
                using HttpClient httpClient = new HttpClient();
                string version = await httpClient.GetStringAsync(gistUrl);
                Version currentVersion = new Version(current);
                Version latestVersion = new Version(version);
                int uptodate = currentVersion.CompareTo(latestVersion);
                if (uptodate < 0)
                {
                    Notification.Show("Notification", $"New update available!\nNew version: {latestVersion}", 6f);
                    string url = "https://github.com/miniusbhater/SP2-Notification-Library/releases/latest/";
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                else
                {
                    Notification.Show("Notification", $"Up to date!", 6f);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
