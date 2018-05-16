using System;
using System.Runtime.Caching;
namespace Recipes.Cache
{
    public abstract class CachingProviderBase
    {
        public CachingProviderBase()
        {
            DeleteLog();
        }

        protected MemoryCache cache = new MemoryCache("CachingProvider");

        static readonly object padlock = new object();

        protected virtual void AddItem(string key, object value)
        {
            lock (padlock)
            {
				cache.Add(key, value, new DateTimeOffset(DateTime.Now.AddHours(1)));
            }
        }

        protected virtual void RemoveItem(string key)
        {
            lock (padlock)
            {
                cache.Remove(key);
            }
        }

        protected virtual object GetItem(string key, bool remove)
        {
            lock (padlock)
            {
                var res = cache[key];

                if (res != null)
                {
                    if (remove == true)
                        cache.Remove(key);
                }
                else
                {
                    WriteToLog("CachingProvider-GetItem: Don't contains key: " + key);
                }

                return res;
            }
        }

        protected virtual bool IsCached(string key)
        {
            lock (padlock)
            {
                var res = cache[key];
                bool isCached = !(res == null);

                if (isCached) {
                    WriteToLog("CachingProvider-IsCached: Contains key: " + key);
                }
                else
                {
                    WriteToLog("CachingProvider-IsCached: Don't contains key: " + key);
                }

                return isCached;
            }
        }

        protected virtual void Dispose()
        {
            lock (padlock)
            {
                cache.Dispose();
            }
        }

        #region Error Logs

        string LogPath = System.Environment.GetEnvironmentVariable("TEMP");

        protected void DeleteLog()
        {
            System.IO.File.Delete(string.Format("{0}\\CachingProvider_Errors.txt", LogPath));
        }

        protected void WriteToLog(string text)
        {
            using (System.IO.TextWriter tw = System.IO.File.AppendText(string.Format("{0}\\CachingProvider_Errors.txt", LogPath)))
            {
                tw.WriteLine(text);
                tw.Close();
            }
        }

        #endregion
    }
}
