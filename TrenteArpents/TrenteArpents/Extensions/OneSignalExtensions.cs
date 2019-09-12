using Com.OneSignal.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TrenteArpents.Extensions
{
    public static class OneSignalExtensions
    {
        public static IDictionary<string, string> ToDictionary(this OSNotification notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            return new Dictionary<string, string>
            {
                { nameof(OSNotification), JsonConvert.SerializeObject(notification) }
            };
        }

        public static IDictionary<string, string> ToDictionary(this OSNotificationOpenedResult result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            return new Dictionary<string, string>
            {
                { nameof(OSNotificationOpenedResult), JsonConvert.SerializeObject(result) }
            };
        }

        public static IDictionary<string, string> ToDictionary(this OSInAppMessageAction inAppMessage)
        {
            if (inAppMessage == null)
            {
                throw new ArgumentNullException(nameof(inAppMessage));
            }

            return new Dictionary<string, string>
            {
                { nameof(OSInAppMessageAction), JsonConvert.SerializeObject(inAppMessage) }
            };
        }
    }
}
