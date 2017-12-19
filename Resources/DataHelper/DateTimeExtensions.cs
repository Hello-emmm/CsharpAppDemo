using System;


namespace moneyShow.Resources.DataHelper
{
	public static class DateTimeExtensions
	{
		public static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
		{
			int diff = dt.DayOfWeek - startOfWeek;
			if (diff < 0)
			{
				diff += 7;
			}

			return dt.AddDays(-1 * diff).Date;
		}

		public static DateTime StartOfYear(DateTime dt)
		{
			return dt.AddDays(-1 * (dt.DayOfYear - 1)).Date;
		}

		public static DateTime StartOfMonth(DateTime dt)
		{
			return dt.AddDays(-1 * (dt.Day - 1)).Date;
		}
	}
}
