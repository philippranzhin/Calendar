using System;
using System.Globalization;
using Xamarin.Forms;

namespace Akvelon.Calendar.Infrastrucure.Behaviors
{
    public class ItemTappedEventArgsToSelectedItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ItemTappedEventArgs eventArgs = value as ItemTappedEventArgs;
            return eventArgs != null ? eventArgs.Item : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new ItemTappedEventArgs(null,value);
        }
    }
}
