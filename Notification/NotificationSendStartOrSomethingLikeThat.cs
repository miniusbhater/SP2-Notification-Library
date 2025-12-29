using System;
using System.Collections.Generic;
using System.Text;
using Notification;

namespace Notification
{
    public class NotificationSendStartOrSomethingLikeThat
    {
        public static void SendNotif()
        {
            string ver;
            ver = PluginInfo.Version.ToString();
            Notification.Show("Notification", $"Notification mod by miniusbhater\nVersion: {ver}", 3f);
        }
    }
}
