using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
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
                CoinViewModel vm = new CoinViewModel(coin, currency);
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
