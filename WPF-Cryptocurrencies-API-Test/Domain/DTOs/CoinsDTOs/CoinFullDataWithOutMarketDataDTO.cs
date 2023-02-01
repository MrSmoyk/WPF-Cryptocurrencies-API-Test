using Domain.DTOs.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.DTOs.CoinsDTOs
{
    public class CoinFullDataWithOutMarketDataDTO : CoinListDTO
    {
        [JsonPropertyName("image")]
        public ImageDTO Image { get; set; }

        [JsonPropertyName("community_data")]
        public CommunityDataDTO CommunityData { get; set; }

        [JsonPropertyName("developer_data")]
        public DeveloperDataDTO DeveloperData { get; set; }

        [JsonPropertyName("public_interest_stats")]
        public PublicInterestStatsDTO PublicInterestStats { get; set; }

        [JsonPropertyName("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonPropertyName("localization")]
        public Dictionary<string, string> Localization { get; set; }
    }

    public class DeveloperDataDTO
    {
        [JsonPropertyName("forks")]
        public long? Forks { get; set; }

        [JsonPropertyName("stars")]
        public long? Stars { get; set; }

        [JsonPropertyName("subscribers")]
        public long? Subscribers { get; set; }

        [JsonPropertyName("total_issues")]
        public long? TotalIssues { get; set; }

        [JsonPropertyName("closed_issues")]
        public long? ClosedIssues { get; set; }

        [JsonPropertyName("pull_requests_merged")]
        public long? PullRequestsMerged { get; set; }

        [JsonPropertyName("pull_request_contributors")]
        public long? PullRequestContributors { get; set; }

        [JsonPropertyName("code_additions_deletions_4_weeks")]
        public Dictionary<string, long?> CodeAdditionsDeletions4Weeks { get; set; }

        [JsonPropertyName("commit_count_4_weeks")]
        public long? CommitCount4Weeks { get; set; }

        [JsonPropertyName("last_4_weeks_commit_activity_series")]
        public long[] Last4WeeksCommitActivitySeries { get; set; }
    }
}
