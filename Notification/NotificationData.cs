using System;
using System.Collections.Generic;
using System.Text;

namespace Notification
{
    internal struct NotificationData
    {
        public string Message;
        public string Sender;
        public float Duration;

        public NotificationData(string message, string sender, float duration)
        {
            Message = message;
            Sender = sender;
            Duration = duration;
        }
    }
}
