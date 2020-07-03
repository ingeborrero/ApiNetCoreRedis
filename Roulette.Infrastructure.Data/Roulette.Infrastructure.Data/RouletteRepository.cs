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

        public bool CreateRoulette(string key, string roulettes)
        {
            var db = _connectionMultiplexer.GetDatabase();

            return db.StringSet(key, roulettes);
        }

        public string GetKeysRedis(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return db.StringGet(key);
        }
    }
}
