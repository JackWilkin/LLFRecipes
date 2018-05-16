using System;
namespace Recipes.Cache
{
    public interface IGlobalCachingProvider
    {
        void AddItem(string key, object value);
        object GetItem(string key);
        bool IsCached(string key);
        void Dispose();
    }
}
