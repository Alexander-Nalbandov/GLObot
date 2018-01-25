﻿using System;
using System.Threading;

namespace Telegram.Bot.GLObot.Notifier.GLO.Checkins
{
    class GLOOfficeTimePoller : IDisposable
    {
        private readonly TimeSpan _period;
        private readonly GLOOfficeTimeClient _client;
        private readonly Action<CheckinDetails> _onNewTimestamp;
        private Timer _timer;

        public GLOOfficeTimePoller(TimeSpan period, GLOOfficeTimeClient client, Action<CheckinDetails> onNewTimestamp)
        {
            _period = period;
            _client = client;
            _onNewTimestamp = onNewTimestamp ?? throw new ArgumentNullException(nameof(onNewTimestamp));
        }

        public void Start(int employeeId)
        {
            _timer = new Timer(async _ =>
            {
                var checkinDetails = await this._client.WhenLastSeen(employeeId);
                this._onNewTimestamp(checkinDetails);
            }, null, TimeSpan.Zero, this._period);
        }

        public void Dispose()
        {
            this._timer?.Dispose();
        }
    }
}