using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Data.Time
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime GetCurrentBrasiliaDate()
        {
            return DateTime.Now.AddHours(-3).Date;
        }
        public DateTime ConvertUtcToBrasilia(DateTime UtcDatatime)
        {
            return UtcDatatime.AddHours(-3);
        }
    }
}