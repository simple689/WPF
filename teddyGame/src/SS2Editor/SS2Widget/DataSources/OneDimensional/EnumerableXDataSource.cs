﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedShark2.DataSources
{
	internal sealed class EnumerableXDataSource<T> : EnumerableDataSource<T>
	{
		public EnumerableXDataSource(IEnumerable<T> data) : base(data) { }
	}
}
