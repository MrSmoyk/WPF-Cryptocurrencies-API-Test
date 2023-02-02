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
using System.Windows.Shapes;

namespace WpfUI.View
{
    /// <summary>
    /// Логика взаимодействия для CoinView.xaml
    /// </summary>
    public partial class CoinView : Window
    {
        public event EventHandler FullyRendered;
        public string Currency { get; set; }
        public CoinMarketsDTO CoinData { get; private set; }

        public CoinView(string coin, string currency)
        {
            InitializeComponent();
        }
    }
}
