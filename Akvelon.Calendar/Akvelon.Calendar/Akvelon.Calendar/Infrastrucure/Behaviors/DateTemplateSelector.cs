using Akvelon.Calendar.ViewModels;
using Xamarin.Forms;

namespace Akvelon.Calendar.Infrastrucure.Behaviors
{
    class DateTemplateSelector : DataTemplateSelector
    {
        public DataTemplate YearTemplate { get; set; }
        public DataTemplate MonthTemplate { get; set; }
        public DataTemplate WeekTemplate { get; set; }
        public DataTemplate DayTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is YearVM)
                return YearTemplate;

            if (item is MonthVM)
                return MonthTemplate;

            if (item is WeekVM)
                return WeekTemplate;

            if (item is DayVM)
                return DayTemplate;

            return null;
        }
    }
}
