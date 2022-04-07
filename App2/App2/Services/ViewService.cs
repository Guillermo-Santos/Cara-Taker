using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Care_Taker.Services
{
    public class ViewService : IViewService
    {
        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task PushAsync(ContentPage page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        public async Task<ContentPage> PopAsync()
        {
            return (ContentPage)await MainPage.Navigation.PopAsync();
        }

        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }
    }
}
