﻿using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Helpers
{
    public static class AutoIncrementHelper
    {
        public static string GetNewCode(string inputValue, AutoIncrement autoIncrement)
        {
            return $"{inputValue}{autoIncrement.Separate}{autoIncrement.Index.ToString(autoIncrement.IndexFormat)}";
        }
    }
}
