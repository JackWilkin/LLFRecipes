using System;
namespace Recipes.Cache
{
    public class GlobalCachingProvider : CachingProviderBase, IGlobalCachingProvider
    {
        #region Singleton 

        protected GlobalCachingProvider()
        {
        }

        public static GlobalCachingProvider Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }
            internal static readonly GlobalCachingProvider instance = new GlobalCachingProvider();
        }

        #endregion

        #region ICachingProvider

        public virtual new void AddItem(string key, object value)
        {
            base.AddItem(key, value);
        }

        public virtual object GetItem(string key)
        {
            return base.GetItem(key, false);//Remove default is true because it's Global Cache!
        }

        public virtual new object GetItem(string key, bool remove)
        {
            return base.GetItem(key, remove);
        }

        public virtual new bool IsCached(string key)
        {
            return base.IsCached(key);
        }

        public virtual new void Dispose() {
            base.Dispose();
        }

        #endregion

    }
}
