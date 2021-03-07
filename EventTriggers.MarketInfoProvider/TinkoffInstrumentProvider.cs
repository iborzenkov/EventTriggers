using System.Collections.Generic;
using System.Linq;
using EventTriggers.Models;
using Tinkoff.Trading.OpenApi.Network;

namespace EventTriggers.MarketInfoProvider
{
    public class TinkoffInstrumentProvider : IInstrumentProvider
    {
        public TinkoffInstrumentProvider()
        {
            var connection = ConnectionFactory.GetSandboxConnection(Consts.Token);
            var q = connection.Context.MarketStocksAsync().Result;
            _instruments.AddRange(q.Instruments.Select(i => new Instrument(i.Name, i.Ticker)));
        }

        public IEnumerable<Instrument> Instruments => _instruments;

        private readonly List<Instrument> _instruments = new List<Instrument>();
    }
}