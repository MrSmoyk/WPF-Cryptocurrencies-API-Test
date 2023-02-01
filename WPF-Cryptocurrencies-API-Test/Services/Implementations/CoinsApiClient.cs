﻿using Domain.Constants;
using Domain.DTOs.CoinsDTOs;
using Domain.Params;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class CoinsApiClient : AsyncApiRepository, ICoinsApiClient
    {
        public CoinsApiClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<IReadOnlyList<CoinFullDataDTO>> GetAllCoinsData()
        {
            return await GetAllCoinsData(OrderField.GeckoDesc, null, null, "", null).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<CoinFullDataDTO>> GetAllCoinsData(string order, int? perPage, int? page, string localization, bool? sparkline)
        {
            return await GetAsync<IReadOnlyList<CoinFullDataDTO>>(QueryStringHelper.AppendQueryString(
                CoinsApiEndPoints.Coins, new Dictionary<string, object>
                {
                {"order", order},
                {"per_page", perPage},
                {"page",page},
                {"localization",localization},
                {"sparkline",sparkline}
                })).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<CoinListDTO>> GetCoinList()
        {
            return await GetAsync<IReadOnlyList<CoinListDTO>>(QueryStringHelper.AppendQueryString(CoinsApiEndPoints.CoinList)).ConfigureAwait(false);
        }
        public async Task<IReadOnlyList<CoinListDTO>> GetCoinList(bool includePlatform)
        {
            return await GetAsync<IReadOnlyList<CoinListDTO>>(QueryStringHelper.AppendQueryString(CoinsApiEndPoints.CoinList,
                new Dictionary<string, object>
                {
                {
                    "include_platform",includePlatform.ToString()
                }
                })).ConfigureAwait(false);
        }

        public async Task<List<CoinMarketsDTO>> GetCoinMarkets(string vsCurrency)
        {
            return await GetCoinMarkets(vsCurrency, new string[] { }, null, null, null, false, null, null).ConfigureAwait(false);
        }

        public async Task<List<CoinMarketsDTO>> GetCoinMarkets(string vsCurrency, string[] ids, string order, int? perPage,
            int? page, bool sparkline, string priceChangePercentage)
        {
            return await GetCoinMarkets(vsCurrency, ids, order, perPage, page, sparkline, priceChangePercentage, null).ConfigureAwait(false);
        }
        public async Task<List<CoinMarketsDTO>> GetCoinMarkets(string vsCurrency, string[] ids, string order, int? perPage,
            int? page, bool sparkline, string priceChangePercentage, string category)
        {
            return await GetAsync<List<CoinMarketsDTO>>(QueryStringHelper.AppendQueryString(CoinsApiEndPoints.CoinMarkets,
                new Dictionary<string, object>
                {
                {"vs_currency", vsCurrency},
                {"ids", string.Join(",", ids)},
                {"order",order},
                {"per_page", perPage},
                {"page", page},
                {"sparkline", sparkline},
                {"price_change_percentage", priceChangePercentage},
                {"category",category}
                })).ConfigureAwait(false);
        }

        public async Task<CoinByIdFullDataDTO> GetAllCoinDataWithId(string id)
        {
            return await GetAllCoinDataWithId(id, "true", true, true, true, true, false).ConfigureAwait(false);
        }

        public async Task<CoinByIdFullDataDTO> GetAllCoinDataWithId(string id, string localization, bool tickers,
            bool marketData, bool communityData, bool developerData, bool sparkline)
        {
            return await GetAsync<CoinByIdFullDataDTO>(QueryStringHelper.AppendQueryString(
                CoinsApiEndPoints.AllDataByCoinId(id), new Dictionary<string, object>
                {
                {"localization", localization},
                {"tickers", tickers},
                {"market_data", marketData},
                {"community_data", communityData},
                {"developer_data", developerData},
                {"sparkline", sparkline}
                })).ConfigureAwait(false);
        }

        public async Task<TickerByIdDTO> GetTickerByCoinId(string id)
        {
            return await GetTickerByCoinId(id, new[] { "" }, null).ConfigureAwait(false);
        }

        public async Task<TickerByIdDTO> GetTickerByCoinId(string id, int? page)
        {
            return await GetTickerByCoinId(id, new[] { "" }, page).ConfigureAwait(false);
        }

        public async Task<TickerByIdDTO> GetTickerByCoinId(string id, string[] exchangeIds, int? page)
        {
            return await GetTickerByCoinId(id, exchangeIds, page, "", OrderField.TrustScoreDesc, false).ConfigureAwait(false);
        }

        public async Task<TickerByIdDTO> GetTickerByCoinId(string id, string[] exchangeIds, int? page, string includeExchangeLogo, string order, bool depth)
        {
            return await GetAsync<TickerByIdDTO>(QueryStringHelper.AppendQueryString(
                CoinsApiEndPoints.TickerByCoinId(id), new Dictionary<string, object>
                {
                {"page", page},
                {"exchange_ids",string.Join(",",exchangeIds)},
                {"include_exchange_logo",includeExchangeLogo},
                {"order",order},
                {"depth",depth.ToString()}
                })).ConfigureAwait(false);
        }
        public async Task<CoinFullDataDTO> GetHistoryByCoinId(string id, string date, string localization)
        {
            return await GetAsync<CoinFullDataDTO>(QueryStringHelper.AppendQueryString(
                CoinsApiEndPoints.HistoryByCoinId(id), new Dictionary<string, object>
                {
                {"date",date},
                {"localization",localization}
                })).ConfigureAwait(false);
        }

        public async Task<MarketChartByIdDTO> GetMarketChartsByCoinId(string id, string vsCurrency, string days)
        {
            return await GetMarketChartsByCoinId(id, vsCurrency, days, "").ConfigureAwait(false);
        }
        public async Task<MarketChartByIdDTO> GetMarketChartsByCoinId(string id, string vsCurrency, string days, string interval)
        {
            return await GetAsync<MarketChartByIdDTO>(QueryStringHelper.AppendQueryString(
                CoinsApiEndPoints.MarketChartByCoinId(id),
                new Dictionary<string, object>
                {
                {"vs_currency", string.Join(",",vsCurrency)},
                {"days", days},
                {"interval",interval}
                })).ConfigureAwait(false);
        }

        public async Task<MarketChartByIdDTO> GetMarketChartRangeByCoinId(string id, string vsCurrency, string @from, string to)
        {
            return await GetAsync<MarketChartByIdDTO>(QueryStringHelper.AppendQueryString(
                CoinsApiEndPoints.MarketChartRangeByCoinId(id), new Dictionary<string, object>
                {
                {"vs_currency", string.Join(",", vsCurrency)},
                {"from",from},
                {"to",to}
                })).ConfigureAwait(false);
        }

    }
}
