using DigitalJournal.MobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DigitalJournal.MobileApp.Views
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