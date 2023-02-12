using Domain.DTOs.SharedDTOs;
using Services.Converters;
using System.Text.Json.Serialization;

namespace Domain.DTOs.CoinsDTOs
{
    public class CoinByIdFullDataDTO : CoinFullDataWithOutMarketDataDTO
    {
        [JsonPropertyName("block_time_in_minutes")]
        public long? BlockTimeInMinutes { get; set; }

        [JsonPropertyName("categories")]
        public string[] Categories { get; set; }

        [JsonPropertyName("description")]
        public Dictionary<string, string> Description { get; set; }

        [JsonPropertyName("links")]
        public LinksDTO Links { get; set; }

        [JsonPropertyName("country_origin")]
        public string CountryOrigin { get; set; }

        [JsonPropertyName("genesis_date")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime GenesisDate { get; set; }

        [JsonPropertyName("market_cap_rank")]
        public long? MarketCapRank { get; set; }

        [JsonPropertyName("coingecko_rank")]
        public long? CoinGeckoRank { get; set; }

        [JsonPropertyName("coingecko_score")]
        public double? CoinGeckoScore { get; set; }

        [JsonPropertyName("developer_score")]
        public double? DeveloperScore { get; set; }

        [JsonPropertyName("community_score")]
        public double? CommunityScore { get; set; }

        [JsonPropertyName("liquidity_score")]
        public double? LiquidityScore { get; set; }

        [JsonPropertyName("public_interest_score")]
        public double? PublicInterestScore { get; set; }

        [JsonPropertyName("market_data")]
        public CoinByIdMarketDataDTO MarketData { get; set; }

        [JsonPropertyName("status_updates")]
        public object[] StatusUpdates { get; set; }

        [JsonPropertyName("tickers")]
        public TickerDTO[] Tickers { get; set; }
    }

    public class CommunityDataDTO
    {
        [JsonPropertyName("facebook_likes")] public double? FacebookLikes { get; set; }

        [JsonPropertyName("twitter_followers")] public double? TwitterFollowers { get; set; }

        [JsonPropertyName("reddit_average_posts_48h")]
        public double? RedditAveragePosts48H { get; set; }

        [JsonPropertyName("reddit_average_comments_48h")]
        public double? RedditAverageComments48H { get; set; }
        [JsonPropertyName("reddit_subscribers")] public double? RedditSubscribers { get; set; }

        [JsonPropertyName("reddit_accounts_active_48h")]
        public double? RedditAccountsActive48H { get; set; }

        [JsonPropertyName("telegram_channel_user_count")]
        public double? TelegramChannelUserCount { get; set; }
    }
}
