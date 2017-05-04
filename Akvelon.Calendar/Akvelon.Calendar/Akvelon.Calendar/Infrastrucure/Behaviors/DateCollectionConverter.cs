using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace Akvelon.Calendar.Infrastrucure.Behaviors
{
    class DateCollectionConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<DateVM> collection = (IEnumerable<DateVM>)value;

            return collection.ElementAt(System.Convert.ToInt32((string)parameter));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
