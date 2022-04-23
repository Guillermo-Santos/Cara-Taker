using System.Threading.Tasks;
using Xamarin.Forms;

namespace Care_Taker.Services
{
    public class ViewService : IViewService
    {
        public async Task DisplayAlert(string title, string message, string ok)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task PushAsync(ContentPage page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task<ContentPage> PopAsync()
        {
            return (ContentPage)await Application.Current.MainPage.Navigation.PopAsync();
        }

        /// <summary>
        /// Asigna una pagina como pagina principal de la aplicacion
        /// </summary>
        /// <param name="page">pagina a volverse mainpage.</param>
        public void SetMainPage(Page page)
        {
            Application.Current.MainPage = page;
        }
    }
}
