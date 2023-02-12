using Domain.Params;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using WpfUI.ViewModels;

namespace WpfUI.View
{
    public partial class HomePage : Page
    {
        private HomeViewModel Context
        {
            get
            {
                return (HomeViewModel)this.DataContext;
            }
        }

        public int CurrentPage { get; set; } = 1;
        public double BackButtonOpacity => CurrentPage == 1 ? 0 : 1;
        public bool SelectedCurrency { get; set; }
        public string[] Currencys { get; set; } = new string[2] { "USD", "EUR" };

        public HomePage()
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();

            Currency.ItemsSource = Currencys;
        }

        private async Task OnSelectCurrency(bool selectedCurrency)
        {
            if (selectedCurrency)
            {
                await Context.GetCoinsAsync("usd");
            }
            else
            {
                await Context.GetCoinsAsync("eur");
            }
        }


        private async void Currency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cont = Currency.SelectedItem as string;

            if (cont == "USD")
            {
                SelectedCurrency = true;
                CurrentCurrency.CurrencyType = '$';

            }
            else if (cont == "EUR")
            {
                SelectedCurrency = false;
                CurrentCurrency.CurrencyType = '€';
            }
            await OnSelectCurrency(SelectedCurrency);
        }

        private void SearchTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            string text = Search.Text;
            if (string.IsNullOrEmpty(text))
            {
                Context.DefaulfTextSorting();

            }
            else
            {
                Context.TextSearch(text);
            }
        }

        private void SelectCoin(object sender, MouseButtonEventArgs e)
        {
            var selectedCoinId = (string)((Panel)sender).Tag;
            string currency = "eur";

            if (SelectedCurrency)
                currency = "usd";

            var w = new CoinView(selectedCoinId, currency);

            NavigationService navigation = NavigationService.GetNavigationService(this);
            navigation.Navigate(w);
        }

        private void PreviousPage(object sender, RoutedEventArgs e)
        {
            if (CurrentPage == 1) return;

            var page = Math.Max(1, CurrentPage - 1);
            Context.PreviousPage();
            Scroller.ScrollToTop();
            CurrentPage = page;

            Scroller.Focus();

        }

        private void NextPage(object sender, RoutedEventArgs e)
        {

            var page = Math.Min(CurrentPage + 1, 100);

            Context.NextPage();
            Scroller.ScrollToTop();
            CurrentPage = page;

            Scroller.Focus();
        }

        private async void RefreshData(object sender, RoutedEventArgs e)
        {
            var cont = Currency.SelectedItem as string;

            if (cont == "USD")
            {
                SelectedCurrency = true;
                CurrentCurrency.CurrencyType = '$';

            }
            else if (cont == "EUR")
            {
                SelectedCurrency = false;
                CurrentCurrency.CurrencyType = '€';
            }
            await OnSelectCurrency(SelectedCurrency);
            SearchTextBox_TextChanged(sender, e);

        }
    }

}
