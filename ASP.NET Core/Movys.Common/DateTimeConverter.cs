namespace Movys.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class DateTimeConverter
    {
        public static double HoursDiffrence(DateTime createdOn)
        {
            return Math.Round((DateTime.UtcNow - createdOn).TotalHours);
        }
    }
}
