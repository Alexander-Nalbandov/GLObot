﻿using System.Threading.Tasks;
using Telegram.Bot.GLObot.Notifier.GLO.Checkins;
using Telegram.Bot.Library;

namespace Telegram.Bot.GLObot.Notifier.Extensions
{
    internal static class Extensions
    {
        public static Task SendEmployeeStatistics(this TelegramBot bot, long chatId, string name, CheckinDetails checkinDetails)
        {
            var direction = checkinDetails.Direction == CheckinDirection.In ? "entering" : "leaving";
            return bot.SendMessage(chatId, $"Employee *{name}* was last seen *{direction.ToUpperInvariant()}* _{checkinDetails.Area}_ at *{checkinDetails.Timestamp}*");
        }
    }
}