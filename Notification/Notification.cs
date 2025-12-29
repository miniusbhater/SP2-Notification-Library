using System;
using System.Collections.Generic;
using System.Text;

namespace Notification
{
    public static class Notification
    {
        internal static Plugin Plugin;

        public static void Show(string message,string sender ,float duration)
        {
            if (Plugin == null)
            {
                NotificationQueue.AddQueue(message, sender, duration);
                return;
            }

            Plugin.ShowNoti(message, sender, duration);
        }
    }
}
