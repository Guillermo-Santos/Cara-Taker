using System.Threading.Tasks;
using Xamarin.Forms;

namespace Care_Taker.Services
{
    public interface IViewService
    {
        /// <summary>
        /// Method to load a <see cref="ContentPage"/> onscreen.
        /// </summary>
        /// <param name="page"><see cref="ContentPage"/> to load.</param>
        /// <returns></returns>
        Task PushAsync(ContentPage page);
        /// <summary>
        /// Return to the last <see cref="ContentPage"/> loaded.
        /// </summary>
        /// <returns> The current <see cref="ContentPage"/></returns>
        Task<ContentPage> PopAsync();
        /// <summary>
        /// Display a message view onscreen.
        /// </summary>
        /// <param name="title">Tittle of the message.</param>
        /// <param name="message">Content of the message.</param>
        /// <param name="ok">Text of the ok button</param>
        /// <param name="cancel">Text of the cancel button</param>
        /// <returns></returns>
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        /// <summary>
        /// Display a message view onscreen.
        /// </summary>
        /// <param name="title">Tittle of the message.</param>
        /// <param name="message">Content of the message.</param>
        /// <param name="ok">Text of the ok button</param>
        /// <returns></returns>
        Task DisplayAlert(string title, string message, string ok);
    }
}
