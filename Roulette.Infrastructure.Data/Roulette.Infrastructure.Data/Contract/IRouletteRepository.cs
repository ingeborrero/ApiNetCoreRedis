namespace Roulette.Infrastructure.Data.Contract
{
    public interface IRouletteRepository
    {
        bool CreateRoulette(string key, string roulettes);
        public string GetKeysRedis(string key);
    }
}
