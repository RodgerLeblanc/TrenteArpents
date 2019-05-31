using System;
using Xamarin.Essentials;

namespace TrenteArpents.Helpers
{
    public class UuidHandler : IUuidHandler
    {
        private const string _uuidKey = "uuidKey";

        static UuidHandler()
        {
            if (VersionTracking.IsFirstLaunchEver)
            {
                CreateUuid();
            }
        }

        public UuidHandler()
        {
            _uuid = new Lazy<string>(() => GetUuid());
        }

        private Lazy<string> _uuid;
        public string Uuid { get => _uuid.Value; }

        private string GetUuid()
        {
            if (!Preferences.ContainsKey(_uuidKey))
            {
                throw new InvalidOperationException("Could not find a unique identifier for this device.");
            }

            return Preferences.Get(_uuidKey, string.Empty);
        }

        private static void CreateUuid()
        {
            Preferences.Set(_uuidKey, GetNewUuid());
        }

        private static string GetNewUuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
