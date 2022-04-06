using Care_Taker.ViewModels;
using Xamarin.Forms;

namespace Care_Taker.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}