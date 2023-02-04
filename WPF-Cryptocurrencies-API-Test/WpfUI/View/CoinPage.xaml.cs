using Domain.DTOs.CoinsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfUI.ViewModels;

namespace WpfUI.View
{
    /// <summary>
    /// Логика взаимодействия для CoinView.xaml
    /// </summary>
    public partial class CoinView : Page
    {

        public CoinView(string coin, string currency)
        {

            InitializeComponent();
            Loaded += (sender, args) =>
            {
                CoinViewModel vm = new CoinViewModel(coin,currency);
                this.DataContext = vm;
            };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var w = new HomePage();

            NavigationService navigation = NavigationService.GetNavigationService(this);
            navigation.Navigate(w);
        }
    }
}
