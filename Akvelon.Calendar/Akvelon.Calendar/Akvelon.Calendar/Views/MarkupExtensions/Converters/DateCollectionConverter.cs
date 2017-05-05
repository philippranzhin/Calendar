// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateCollectionConverter.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The date collection converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Views.MarkupExtensions.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Akvelon.Calendar.Infrastrucure.DateVmBase;

    using Xamarin.Forms;

    /// <summary>
    /// The enumerable to item converter. Gets value as iEnumerable, parametr as int and return an element at (parametr) of the collection
    /// </summary>
    public class EnumerableToItemConverter : IValueConverter
    {
        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="value">
        /// The enumerable.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parameter">
        /// The index of item.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<object> collection = (IEnumerable<object>)value;

            return collection.ElementAt(System.Convert.ToInt32((string)parameter));
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
            return null;
        }
    }
}