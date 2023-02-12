namespace Domain.Constants
{
    public static class CoinsApiEndPoints
    {
        public static readonly string Coins = "coins";

        public static readonly string CoinList = "coins/list";

        public static readonly string CoinMarkets = "coins/markets";

        public static string AllDataByCoinId(string id) => CoinGecoAPIEndPoints.AddCoinsId(id);
        public static string TickerByCoinId(string id) => CoinGecoAPIEndPoints.AddCoinsId(id) + "/tickers";
        public static string HistoryByCoinId(string id) => CoinGecoAPIEndPoints.AddCoinsId(id) + "/history";
        public static string MarketChartByCoinId(string id) => CoinGecoAPIEndPoints.AddCoinsId(id) + "/market_chart";
        public static string MarketChartRangeByCoinId(string id) => CoinGecoAPIEndPoints.AddCoinsId(id) + "/market_chart/range";
        public static string StatusUpdates(string id) => CoinGecoAPIEndPoints.AddCoinsId(id) + "/status_updates";
    }
}
