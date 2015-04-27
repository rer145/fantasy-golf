﻿using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace RonsHouse.FantasyGolf.Services
{
	public class CacheService
	{
		protected ObjectCache Cache
		{
			get { return MemoryCache.Default; }
		}
		
		public T Get<T>(string key)
		{
			return (T)Cache[key];
		}

		public void Set(string key, object data, int cacheTime)
		{
			if (data == null)
				return;

			var policy = new CacheItemPolicy();
			policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
			Cache.Add(new CacheItem(key, data), policy);
		}

		public bool IsSet(string key)
		{
			return (Cache.Contains(key));
		}

		public void Remove(string key)
		{
			Cache.Remove(key);
		}

		public void RemoveByPattern(string pattern)
		{
			var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
			var keysToRemove = new List<String>();

			foreach (var item in Cache)
				if (regex.IsMatch(item.Key))
					keysToRemove.Add(item.Key);

			foreach (string key in keysToRemove)
			{
				Remove(key);
			}
		}

		public virtual void Clear()
		{
			foreach (var item in Cache)
				Remove(item.Key);
		}
	}

	public static class CacheServiceExtensions
	{
		private static readonly object _syncObject = new object();

		public static T Get<T>(this CacheService cacheService, string key, Func<T> acquire)
		{
			return Get(cacheService, key, 60, acquire);
		}

		public static T Get<T>(this CacheService cacheService, string key, int cacheTime, Func<T> acquire)
		{
			lock (_syncObject)
			{
				if (cacheService.IsSet(key))
				{
					return cacheService.Get<T>(key);
				}

				var result = acquire();
				if (cacheTime > 0)
					cacheService.Set(key, result, cacheTime);
				return result;
			}
		}
	}
}