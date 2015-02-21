using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace FlyoutProblem.Converters
{
    public class DepthToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var v = (value as int?) * 20;
            return new Thickness(System.Convert.ToDouble(v), 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var t = value is Thickness ? (Thickness)value : new Thickness();
            return t.Left / 20;
        }
    }
}
