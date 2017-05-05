// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeekView.xaml.cs" company="Akvelon">
//   Philipp Ranzhin
// </copyright>
// <summary>
//   The week view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Akvelon.Calendar.Views
{
    using System.Linq;

    using Akvelon.Calendar.ViewModels;

    using Xamarin.Forms;

    /// <summary>
    ///     The week view.
    /// </summary>
    public partial class WeekView : ContentView
    {
        /// <summary>
        ///     The month property.
        /// </summary>
        public static readonly BindableProperty MonthProperty =
            BindableProperty.Create("Month", typeof(MonthVm), typeof(MonthVm), null);

        /// <summary>
        ///     The week property.
        /// </summary>
        public static readonly BindableProperty WeekProperty =
            BindableProperty.Create("Week", typeof(WeekVm), typeof(WeekVm), null);

        /// <summary>
        ///     Initializes a new instance of the <see cref="WeekView" /> class.
        /// </summary>
        public WeekView()
        {
            this.InitializeComponent();
          
        }

        /// <summary>
        ///     Gets or sets the month.
        /// </summary>
        public MonthVm Month
        {
            get
            {
                return (MonthVm)this.GetValue(MonthProperty);
            }

            set
            {
                this.SetValue(MonthProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the week.
        /// </summary>
        public WeekVm Week
        {
            get
            {
                return (WeekVm)this.GetValue(WeekProperty);
            }

            set
            {
                this.SetValue(WeekProperty, value);
            }
        }
    }
}