﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nest
{
	internal static class IdExtensions
    {
		internal static bool IsConditionless(this Id id)
		{
			return id == null || (id.Value == null && id.Document == null);
		}
	}
}
