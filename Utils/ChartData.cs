using System;

namespace TauManager.Core.Utils
{
    public class ChartData
    {
        public enum Interval: byte { Week, Month1, Month3, Month6, Year, Max }
        public static DateTime? MoveDateByInterval(DateTime startDate, Interval interval)
        {
            DateTime? result = null;
            switch (interval)
            {
                case Interval.Week:
                    result = startDate.AddDays(-7); break;
                case Interval.Month1:
                    result = startDate.AddMonths(-1); break;
                case Interval.Month3:
                    result = startDate.AddMonths(-3); break;
                case Interval.Month6:
                    result = startDate.AddMonths(-6); break;
                case Interval.Year:
                    result = startDate.AddYears(-1); break;
                case Interval.Max:
                    result = new DateTime(2018, 10, 28); break; // The Manager has received first data in October 2018
            }
            return result;
        }
    }
}