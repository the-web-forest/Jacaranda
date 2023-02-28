using System;
namespace Jacaranda.Util
{
	public class DateHelper
	{
        public static DateTime BrazilDateTimeNow() => TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
    }
}

