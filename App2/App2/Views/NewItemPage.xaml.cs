using Care_Taker.Models;
using Care_Taker.ViewModels;
using Xamarin.Forms;

namespace Care_Taker.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}