using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DarkSky.Core
{
    // StorageManager class
    public static class StorageManager
    {
        private static ApplicationDataContainer localSettings;
        private static StorageFolder localFolder;

        public static void Init()
        {
            localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        }

        public static Object ReadSimpleSetting(string id)
        {
            if (localSettings != null && localFolder != null)
            {
                try
                {
                    return localSettings.Values[id];
                }
                catch (System.NullReferenceException ex)
                {
                    Debug.WriteLine("No save data located: " + ex.Message);
                };
            }
            else DebugWarnNotInitialised();

            return null;
        }

        public static void WriteSimpleSetting(string id, Object toStore)
        {
            if (localSettings != null && localFolder != null)
            {
                try
                {
                    localSettings.Values[id] = toStore;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("[ex] WriteSimpleSetting exception: " + ex.Message);
                }
            }
            else DebugWarnNotInitialised();
        }

        private static void DebugWarnNotInitialised()
        {
            Debug.WriteLine(@"Have you called ""StorageManager.Init()""?");
        }
    }//StorageManager class end
}
