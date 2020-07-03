using Roulette.Infrastructure.Data.Contract;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Infrastructure.Data
{
    public class RouletteRepository: IRouletteRepository
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        public RouletteRepository(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public int CreateRoulette(string key, string value)
        {
            //Aca iria a la BD
            var db = _connectionMultiplexer.GetDatabase();
            db.StringSet(key, value);
            return Int32.Parse(value);
        }
    }
}
