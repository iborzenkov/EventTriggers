using Tinkoff.Trading.OpenApi.Network;

namespace EventTriggers.MarketInfoProvider
{
    internal class Connection
    {
        public Connection(string token)
        {
            _token = token;
        }

        public Context Context => _context ?? (_context = ConnectionFactory.GetConnection(_token).Context);
        
        private Context _context;
        private readonly string _token;
    }
}