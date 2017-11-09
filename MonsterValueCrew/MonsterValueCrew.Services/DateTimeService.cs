﻿using System;

namespace MonsterValueCrew.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentDate()
        {
            return new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
        }
    }
}
