using DigittalJournal.MobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DigittalJournal.MobileApp.Views
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