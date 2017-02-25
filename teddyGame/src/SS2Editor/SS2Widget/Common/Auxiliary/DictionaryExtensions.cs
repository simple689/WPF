﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedShark2.Charts.Isolines;

namespace SpeedShark2.Common.Auxiliary
{
	internal static class DictionaryExtensions
	{
		internal static void Add<TKey, TValue>(this Dictionary<TKey, TValue> dict, TValue value, params TKey[] keys)
		{
			foreach (var key in keys)
			{
				dict.Add(key, value);
			}
		}

		internal static void Add(this Dictionary<int, Edge> dict, Edge value, params CellBitmask[] keys)
		{
			foreach (var key in keys)
			{
				dict.Add((int)key, value);
			}
		}
	}
}
