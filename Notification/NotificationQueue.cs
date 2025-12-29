using System;
using System.Collections.Generic;
using System.Text;

namespace Notification
{
    internal static class NotificationQueue
    {
        private static readonly Queue<NotificationData> queue =
            new Queue<NotificationData>();

        public static void AddQueue(string msg, string sender, float duration)
        {
            queue.Enqueue(new NotificationData(msg, sender, duration));
        }

        public static void Flush(Plugin plugin)
        {
            while (queue.Count > 0)
            {
                NotificationData data = queue.Dequeue();
                plugin.ShowNoti(data.Message, data.Sender, data.Duration);
            }
        }
    }
}
