// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsDayOfMonthConverter.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The is day of month converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


// TODO remake this
namespace Akvelon.Calendar.Views.MarkupExtensions.Converters
{
    using System;
    using System.Globalization;

    using Akvelon.Calendar.Models;

    using Xamarin.Forms;

    /// <summary>
    ///     The is day of month converter.
    /// </summary>
    internal class IsDayOfMonthConverter : IValueConverter
    {
        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateInfoModel) || !(parameter is Binding))
            {
                return false;
            }

            Label label = ((Binding)parameter).Source as Label;
            DateInfoModel dateInfoModel = label?.BindingContext as DateInfoModel;
            return dateInfoModel?.Compare(((DateInfoModel)value).Date) == true;
        }

        /// <summary>
        /// The convert back.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}