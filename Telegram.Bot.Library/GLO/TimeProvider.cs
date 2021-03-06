﻿using System;

namespace Telegram.Bot.Library.GLO
{
    internal static class TimeProvider
    {
        private static readonly Func<DateTime> s_timeFunc;
        static TimeProvider()
        {
            s_timeFunc = () => DateTime.UtcNow;
        }

        public static DateTime Now => s_timeFunc();

        public static DateTime Today => Now.Date;

        public static long NowMilliseconds => TimeUtility.DateToMilliseconds(Now);

        public static long TodayMilliseconds => TimeUtility.DateToMilliseconds(Today);
    }
}
