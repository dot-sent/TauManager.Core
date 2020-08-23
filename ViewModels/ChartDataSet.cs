using System;
using System.Collections.Generic;

namespace TauManager.ViewModels
{
    ///
    /// <summary>Class <c>CharDataSet</c> represents a dataset for a chart or graph. It is basically a <c>List</c>
    /// that contains the datapoints plus utilitary enums to be used for configuring the chart or graph.</summary>
    ///
    public class ChartDataSet: List<ChartDataPoint>
    {
        public enum Interval: byte { Week, Month1, Month3, Month6, Year, Max }
        public enum DataKind: byte { StatsTotal, Credits, Bonds, XP, MemberCount }
        public static DateTime? GetStartDate(byte interval)
        {
            DateTime? startDate = null;
            switch (interval)
            {
                case (byte)ChartDataSet.Interval.Week:
                    startDate = DateTime.Today.AddDays(-7); break;
                case (byte)ChartDataSet.Interval.Month1:
                    startDate = DateTime.Today.AddMonths(-1); break;
                case (byte)ChartDataSet.Interval.Month3:
                    startDate = DateTime.Today.AddMonths(-3); break;
                case (byte)ChartDataSet.Interval.Month6:
                    startDate = DateTime.Today.AddMonths(-6); break;
                case (byte)ChartDataSet.Interval.Year:
                    startDate = DateTime.Today.AddYears(-1); break;
                case (byte)ChartDataSet.Interval.Max:
                    startDate = new DateTime(2018, 10, 28); break; // The Manager has received first data in October 2018
            }
            return startDate;
        }
    }
}