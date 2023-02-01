using Domain.DTOs.CoinsDTOs;

namespace Services.Interfaces
{
    public interface ICoinsApiClient
    {
        Task<IReadOnlyList<CoinListDTO>> GetCoinList();

        Task<IReadOnlyList<CoinFullDataDTO>> GetAllCoinsData();

        Task<IReadOnlyList<CoinFullDataDTO>> GetAllCoinsData(string order, int? perPage, int? page, string localization,
       bool? sparkline);

        Task<IReadOnlyList<CoinListDTO>> GetCoinList(bool includePlatform);

        Task<List<CoinMarketsDTO>> GetCoinMarkets(string vsCurrency);

        Task<List<CoinMarketsDTO>> GetCoinMarkets(string vsCurrency, string[] ids, string order, int? perPage, int? page,
    bool sparkline, string priceChangePercentage, string category);

        Task<CoinByIdFullDataDTO> GetAllCoinDataWithId(string id);

        Task<CoinByIdFullDataDTO> GetAllCoinDataWithId(string id, string localization, bool tickers,
    bool marketData, bool communityData, bool developerData, bool sparkline);

        Task<TickerByIdDTO> GetTickerByCoinId(string id);

        Task<TickerByIdDTO> GetTickerByCoinId(string id, int? page);

        Task<TickerByIdDTO> GetTickerByCoinId(string id, string[] exchangeIds, int? page);

        Task<TickerByIdDTO> GetTickerByCoinId(string id, string[] exchangeIds, int? page, string includeExchangeLogo,
            string order, bool depth);

        Task<CoinFullDataDTO> GetHistoryByCoinId(string id, string date, string localization);

        Task<MarketChartByIdDTO> GetMarketChartsByCoinId(string id, string vsCurrency, string days);

        Task<MarketChartByIdDTO> GetMarketChartsByCoinId(string id, string vsCurrency, string days, string interval);

        Task<MarketChartByIdDTO> GetMarketChartRangeByCoinId(string id, string vsCurrency, string from, string to);

    }
}
