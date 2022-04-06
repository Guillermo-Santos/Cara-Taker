using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace Care_Taker.Services
{
    public class AppointmentSelector : DataTemplateSelector
    {
        public DataTemplate AppointmentTemplate { get; set; }
        public DataTemplate AllDayAppointmentTemplate { get; set; }
        public AppointmentSelector()
        {
            AppointmentTemplate = new DataTemplate(typeof(AppointmentTemplate));
            AllDayAppointmentTemplate = new DataTemplate(typeof(AllDayAppointmentTemplate));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var calendar = (container as SfCalendar);
            if (calendar == null)
            {
                return null;
            }
            if ((item as CalendarInlineEvent).IsAllDay)
            {
                return AllDayAppointmentTemplate;
            }
            else
            {
                return AppointmentTemplate;
            }
        }
    }
}
