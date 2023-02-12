using Domain.DTOs.CoinsDTOs;
using Services.Implementations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.ViewModels
{
    public class CoinViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private CoinGeckoApiClient apiClient { get; } = new();

        public ObservableCollection<string> DescriptionRows { get; set; } = new();
        public string Currency { get; set; }

        public CoinViewModel()
        {
        }

        public CoinViewModel(string coin, string vsCurrency)
        {
            Currency = vsCurrency;
            Task.Run(async () => await GetCoinAsync(coin, vsCurrency)).Wait();
        }

        public CoinMarketsDTO CoinData { get; private set; }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public async Task GetCoinAsync(string coin, string vsCurrency)
        {
            var data = (await apiClient.CoinsApiClient.GetCoinMarkets(
                vsCurrency: vsCurrency,
                ids: new[] { coin },
                order: "market_cap_desc",
                perPage: 1,
                page: 0,
                sparkline: false,
                priceChangePercentage: "24h,7d",
                category: ""
                )).FirstOrDefault();

            CoinData = data;

            var descriptionData = await apiClient.CoinsApiClient.GetAllCoinDataWithId(coin, "false", false, false, false, false, false);
            var descriptionTextBlocks = StringToTextBlocks(descriptionData.Description["en"]);
            foreach (var t in descriptionTextBlocks)
            {
                DescriptionRows.Add(t);
            }
        }

        private static IEnumerable<string> StringToTextBlocks(string input)
        {
            var tagFound = false;
            StringBuilder sb = new();

            foreach (var t in input)
            {
                if (t == '<') tagFound = true;
                if (!tagFound) sb.Append(t);
                if (t == '>') tagFound = false;
            }

            return sb.ToString().Split("\r\n\r\n");
        }
    }
}
