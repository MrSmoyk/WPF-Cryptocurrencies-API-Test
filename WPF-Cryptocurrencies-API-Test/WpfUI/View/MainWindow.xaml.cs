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
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfUI.ViewModels;

namespace WpfUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public record Currency(string Name, string Symbol, string Id);

    public partial class MainWindow : Window
    {
        private MainViewModel Context
        {
            get
            {
               return (MainViewModel)this.DataContext;
            }
        }
        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();
        }

        private void SelectCoin(object sender, MouseButtonEventArgs e)
        {
            var selectedCoinId = (string)((Panel)sender).Tag;

            var w = new CoinView(selectedCoinId, "usd");
        }

    }
}
