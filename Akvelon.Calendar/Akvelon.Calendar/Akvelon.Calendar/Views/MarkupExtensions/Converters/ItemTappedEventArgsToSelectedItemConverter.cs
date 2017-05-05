// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemTappedEventArgsToSelectedItemConverter.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The item tapped event args to selected item converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Views.MarkupExtensions.Converters
{
    using System;
    using System.Globalization;

    using Xamarin.Forms;

    /// <summary>
    ///     The item tapped event args to selected item converter. Gets item from eventArgs
    /// </summary>
    public class ItemTappedEventArgsToSelectedItemConverter : IValueConverter
    {
        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="value">
        /// The ItemTappedEventArgs. 
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
            ItemTappedEventArgs eventArgs = value as ItemTappedEventArgs;
            return eventArgs != null ? eventArgs.Item : null;
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
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new ItemTappedEventArgs(null, value);
        }
    }
}