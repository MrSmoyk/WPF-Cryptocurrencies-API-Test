using Domain.DTOs.CoinsDTOs;
using Services.Implementations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private CoinGeckoApiClient apiClient { get;} = new();

        public ObservableCollection<CoinMarketsDTO> CoinsToPage { get; set; } = new();

        public PageableCollection<CoinMarketsDTO> Coins { get; set; }

        public List<string> ImageUri { get; set; } = new();

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public HomeViewModel()
        {
            var vs = "usd";
            Task.Run(async() => await GetCoinsAsync(vs)).Wait();
        }

        public async Task GetCoinsAsync(string vsCurrency)
        {
            var coins = await apiClient.CoinsApiClient.GetCoinMarkets(vsCurrency: vsCurrency,
                ids: Array.Empty<string>(),
                order: "market_cap_desc",
                perPage: 90,
                page: 1,
                sparkline: true,
                priceChangePercentage: "24h,7d",
                category: "");

            Coins = new PageableCollection<CoinMarketsDTO>(coins);
            CoinsToPage.Clear();

            foreach (var coin in Coins.CurrentPageItems)
            {
                CoinsToPage.Add(coin);
            }

        }

        public void TextSearch(string text)
       {
            List<CoinMarketsDTO> coinsListToSort = Coins.AllObjects.ToList();
            List<CoinMarketsDTO> sortedList = coinsListToSort.FindAll(x => x.Id.Contains(text.ToLower()));
            foreach (var coin in sortedList)
            {
                coinsListToSort.Remove(coin);
            }
            sortedList.AddRange(coinsListToSort);

            Coins = new PageableCollection<CoinMarketsDTO>(sortedList);
            CoinsToPage.Clear();

            foreach(var coin in Coins.CurrentPageItems)
            {
                CoinsToPage.Add(coin);
            }
            

        }

        public void DefaulfTextSorting()
        {
            List<CoinMarketsDTO> coinsListToSort = Coins.AllObjects.ToList();
            coinsListToSort.Sort((x, y) => ((long)x.MarketCapRank).CompareTo(y.MarketCapRank));

            Coins = new PageableCollection<CoinMarketsDTO>(coinsListToSort);

            CoinsToPage.Clear();

            foreach (var coin in Coins.CurrentPageItems)
            {
                CoinsToPage.Add(coin);
            }
        }

        public void NextPage()
        {
            Coins.GoToNextPage();
            CoinsToPage.Clear();

            foreach (var coin in Coins.CurrentPageItems)
            {
                CoinsToPage.Add(coin);
            }
        }

        public void PreviousPage()
        {
            Coins.GoToPreviousPage();
            CoinsToPage.Clear();

            foreach (var coin in Coins.CurrentPageItems)
            {
                CoinsToPage.Add(coin);
            }

        }
    }

    

    public class PageableCollection<T> : ObservableCollection<T> , INotifyPropertyChanged
    {
        private int _pageSize = 30;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if (_pageSize != value)
                {
                    _pageSize = value;
                    SendPropertyChanged(() => PageSize);
                    Reset();
                }
            }
        }

        public int TotalPagesNumber
        {
            get
            {
                if (AllObjects != null && PageSize > 0)
                {
                    return (AllObjects.Count - 1) / PageSize + 1;
                }
                return 0;
            }
        }

        private int _currentPageNumber = 1;
        public int CurrentPageNumber
        {
            get
            {
                return _currentPageNumber;
            }

            protected set
            {
                if (_currentPageNumber != value)
                {
                    _currentPageNumber = value;
                    SendPropertyChanged(() => CurrentPageNumber);
                }
            }
        }

        private List<T> _currentPageItems;
        public List<T> CurrentPageItems
        {
            get
            {
                return _currentPageItems;
            }
            private set
            {
                if (_currentPageItems != value)
                {
                    _currentPageItems = value;
                    SendPropertyChanged(() => CurrentPageItems);
                }
            }
        }

        public ObservableCollection<T> AllObjects { get; set; }

        protected PageableCollection()
        {
        }

        public PageableCollection(IEnumerable<T> allObjects, int? entriesPerPage = null)
        {
            AllObjects = new ObservableCollection<T>(allObjects);
            if (entriesPerPage != null)
                PageSize = (int)entriesPerPage;
            Calculate(CurrentPageNumber);
        }

        public void GoToNextPage()
        {
            if (CurrentPageNumber != TotalPagesNumber)
            {
                CurrentPageNumber++;
                Calculate(CurrentPageNumber);
            }
        }

        public void GoToPreviousPage()
        {
            if (CurrentPageNumber > 1)
            {
                CurrentPageNumber--;
                Calculate(CurrentPageNumber);
            }
        }

        public virtual void Remove(T item)
        {
            AllObjects.Remove(item);

            // Update the total number of pages
            SendPropertyChanged(() => TotalPagesNumber);

            // if the last item on the last page is removed
            if (CurrentPageNumber > TotalPagesNumber)
                CurrentPageNumber--;

            Calculate(CurrentPageNumber);
        }

        public virtual void Add(T item)
        {
            CurrentPageNumber = 1;
            Calculate(CurrentPageNumber);

            CurrentPageItems.RemoveAt(CurrentPageItems.Count - 1);
            CurrentPageItems.Insert(0, item);

            AllObjects.Add(item);
            SendPropertyChanged(() => TotalPagesNumber);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void SendPropertyChanged<T>(Expression<Func<T>> expression)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(((MemberExpression)expression.Body).Member.Name));
            }
        }
        protected void Calculate(int pageNumber)
        {
            int upperLimit = pageNumber * PageSize;

            CurrentPageItems =
                new List<T>(
                    AllObjects.Where(x => AllObjects.IndexOf(x) > upperLimit - (PageSize + 1) && AllObjects.IndexOf(x) < upperLimit));
        }

        private void Reset()
        {
            CurrentPageNumber = 1;
            Calculate(CurrentPageNumber);
            SendPropertyChanged(() => TotalPagesNumber);
        }
    }
}
