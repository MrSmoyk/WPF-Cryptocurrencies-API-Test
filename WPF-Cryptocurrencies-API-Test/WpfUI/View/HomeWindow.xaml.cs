using CommunityToolkit.Mvvm.Input;
using Domain.DTOs.CoinsDTOs;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfUI.ViewModels;

namespace WpfUI.View
{
    public partial class HomeWindow : Window
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

        public HomeWindow()
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
            
        }

        private async Task OnSelectCurrency(bool selectedCurrency)
        {
            if(selectedCurrency)
            {
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                await Context.GetCoinsAsync("usd");
            }else
            {
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo("eur");
                await Context.GetCoinsAsync("en-IE");
            }

            
        }


        private async void Currency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Currency.SelectedItem == "USD")
            {
                SelectedCurrency = true;
            }else if(Currency.SelectedItem == "EUR")
            {
                SelectedCurrency = false;
            }

            await OnSelectCurrency(SelectedCurrency);
        }

        private void SearchTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            string text = Search.Text;
            if (string.IsNullOrEmpty(text))
            {
                Context.DefaulfTextSorting();
              
            }else
            {
                Context.TextSearch(text);
            }
        }

        private void SelectCoin(object sender, MouseButtonEventArgs e)
        {
            var selectedCoinId = (string)((Panel)sender).Tag;

            var w = new CoinView(selectedCoinId,"usd");
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

        private void NextPage (object sender, RoutedEventArgs e)
        {
  
            var page = Math.Min(CurrentPage + 1, 100);
           
            Context.NextPage();
            Scroller.ScrollToTop();
            CurrentPage = page;

            Scroller.Focus();
        }

    }
}
