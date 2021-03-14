using EventTriggers.Models;
using System.Collections.Generic;
using System.Linq;
using Tinkoff.Trading.OpenApi.Network;

namespace EventTriggers.MarketInfoProvider
{
    public class TinkoffInstrumentProvider : IInstrumentProvider
    {
        public TinkoffInstrumentProvider()
        {
            var connection = ConnectionFactory.GetSandboxConnection(Consts.Token);
            var instrumentList = connection.Context.MarketStocksAsync().Result;
            _instruments.AddRange(instrumentList.Instruments.Select(i => new Instrument(i.Name, i.Ticker)));
        }

        public IEnumerable<Instrument> Instruments => _instruments;

        private readonly List<Instrument> _instruments = new List<Instrument>();
    }
}