using System.Threading.Tasks;
using Xamarin.Forms;

namespace Care_Taker.Services
{
    public interface IViewService
    {
        Task PushAsync(ContentPage page);
        Task<ContentPage> PopAsync();
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);
    }
}
