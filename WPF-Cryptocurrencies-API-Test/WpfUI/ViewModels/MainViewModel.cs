using Domain.DTOs.CoinsDTOs;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private CoinGeckoApiClient apiClient { get;} = new();

        public ObservableCollection<CoinMarketsDTO> Coins { get; set; } = new();

        public List<string> ImageUri { get; set; } = new();

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainViewModel()
        {
           var t = Task.Run(async() => await GetCoinsAsync());
            Task.WaitAll(t);
        }

        private async Task GetCoinsAsync()
        {
            var coins = await apiClient.CoinsApiClient.GetCoinMarkets(vsCurrency: "usd",
                ids: Array.Empty<string>(),
                order: "market_cap_desc",
                perPage: 30,
                page: 1,
                sparkline: true,
                priceChangePercentage: "24h,7d",
                category: "");

            foreach(var coin in coins)
            {
                ImageUri.Add(coin.Image.ToString());
                Coins.Add(coin);
            }
        }
    }
}
