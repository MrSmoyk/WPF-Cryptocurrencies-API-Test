namespace Domain.Constants
{
    public static class CoinGecoAPIEndPoints
    {
        public static Uri ApiEndPoint = new("https://api.coingecko.com/api/v3/");

        public static string AddCoinsId(string id) => "coins/" + id;
    }
}
