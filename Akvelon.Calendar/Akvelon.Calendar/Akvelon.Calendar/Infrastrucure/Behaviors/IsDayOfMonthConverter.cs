using System;
using System.Globalization;
using Akvelon.Calendar.Models;
using Xamarin.Forms;

namespace Akvelon.Calendar.Infrastrucure.Behaviors
{
    class IsDayOfMonthConverter : IValueConverter
    {
        //TODO REMAKE
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateInfoModel) || !(parameter is Xamarin.Forms.Binding))
                return false;

            Label label = ((Xamarin.Forms.Binding) parameter).Source as Label;
            if (label != null)
            {
                DateInfoModel dateInfoModel = label.BindingContext as DateInfoModel;
                return dateInfoModel != null && (dateInfoModel.Compare((value as DateInfoModel).Date));
            }
            else return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
