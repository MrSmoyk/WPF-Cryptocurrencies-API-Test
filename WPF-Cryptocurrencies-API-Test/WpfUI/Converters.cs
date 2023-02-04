using Domain.DTOs.CoinsDTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WpfUI.View;

namespace WpfUI
{

    public class ToUpper : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;
            return value.ToString().ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class DecimalToVariableCurrency : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return string.Empty;

            var price = (decimal)value;

            int precision;
            if (price >= 1 || price < 0) precision = 2;
            else if (price > 0.099M) precision = 4;
            else precision = (int)Math.Log10((double)(1M / price)) * 2;
            var str = string.Format(CultureInfo.CurrentCulture, "{0:C" + precision + "}", price);
            var curStr = Static.CurrencyType + str.Remove(0, 1);
            return curStr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DecimalToZeroCurrency : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var curStr = Static.CurrencyType + ((decimal)value).ToString("C0", CultureInfo.CurrentCulture).Remove(0, 1);
            return curStr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DecimalDivision : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format(CultureInfo.CurrentCulture,
                "{0:N5}", values[0] is not decimal a || values[1] is not decimal b ? 0 : b / a)
;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CurrencyVolumeToVolume : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var markets = value as CoinMarketsDTO;
            return string.Format(
                CultureInfo.CurrentCulture,
                "{0:N0} {1}",
                markets.TotalVolume / markets.CurrentPrice,
                markets.Symbol.ToUpper()
            );
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SupplyWithSymbol : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var markets = value as CoinMarketsDTO;
            return string.Format(
                CultureInfo.CurrentCulture,
                "{0:N0} {1}",
                markets.CirculatingSupply,
                markets.Symbol.ToUpper()
            );
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SparklineToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var markets = value as CoinMarketsDTO;
            if (markets.SparklineIn7D.Price.First() > markets.SparklineIn7D.Price.Last())
            {
                return "#D6455D";
            }
            return "#4fc280";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SparklineToSvg : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            culture = CultureInfo.InvariantCulture;

            int index = 0;
            var markets = value as CoinMarketsDTO;
            var max = markets.SparklineIn7D.Price.Max();
            var avg = markets.SparklineIn7D.Price.Average();
            var coef = max - avg;
            var scale = 14 / (coef == 0 ? 14 : coef);

            string path = markets.SparklineIn7D.Price.Aggregate("", (path, price) =>
            {
                char instruction = index == 0 ? 'M' : 'L';
                path = string.Format(
                    culture,
                    "{0} {1}{2} {3:0.###}",
                    path,
                    instruction,
                    index,
                    (max - price) * scale
                );
                index++;
                return path;
            });
            return path;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PercentToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (decimal)value >= 0 ? "#16c784" : "#ea3943";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PercentToText : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null) return string.Empty;
            decimal percentage = (decimal)value;
            return (percentage >= 0 ? "⏶" : "⏷") + Math.Abs(percentage / 100).ToString("P", CultureInfo.InvariantCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class CurrencyToVisibility : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is not string selectedCurrency ||
                values[1] is not string parameterCurrency
            ) return Visibility.Collapsed;

            return selectedCurrency == parameterCurrency ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class NullToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
