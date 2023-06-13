using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DEMOFiltros.Extensions.Filters
{
    class CacheEntry
    {
        public DateTime CachedAt { get; set; }
        public ContentResult? Content { get; set; }
    }

    public class SimpleCacheAttribute : Attribute, IResourceFilter
    {
        private static readonly Dictionary<string, CacheEntry> Cache = new Dictionary<string, CacheEntry>();

        private string? _cacheKey;

        // Antes de ejecutar la acción se comprueba si tenemos el resultado en caché
        // retornándolo en caso afirmativo
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _cacheKey = context.HttpContext.Request.Path.ToString();
            if (Cache.ContainsKey(_cacheKey))
            {
                var cacheEntry = Cache[_cacheKey];
                if (cacheEntry != null)
                {
                    if (DateTime.Now.Subtract(cacheEntry.CachedAt) > TimeSpan.FromSeconds(10))
                    {
                        Cache.Remove(_cacheKey);
                    }
                    else
                    {
                        context.Result = cacheEntry.Content;
                    }
                }
            }
        }

        // Tras ejecutar la acción, guardamos en el diccionario los ContentResult
        // para usos posteriores
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (!String.IsNullOrEmpty(_cacheKey) && !Cache.ContainsKey(_cacheKey))
            {
                if (context.Result is ContentResult result)
                {
                    var cacheEntry = new CacheEntry()
                    {
                        CachedAt = DateTime.Now,
                        Content = result
                    };
                    Cache.Add(_cacheKey, cacheEntry);
                }
            }
        }
    }
}
