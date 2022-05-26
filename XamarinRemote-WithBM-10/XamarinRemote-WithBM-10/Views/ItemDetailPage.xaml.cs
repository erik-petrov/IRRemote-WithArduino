using System.ComponentModel;
using Xamarin.Forms;
using XamarinRemote_WithBM_10.ViewModels;

namespace XamarinRemote_WithBM_10.Views
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