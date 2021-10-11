using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JTea_DPS926_Assignment2
{
    public partial class MainPage : ContentPage
    {
        // constructor (0 params required)
        public MainPage()
        {
            InitializeComponent();
            cryptoImage.Source = ImageSource.FromResource("JTea_DPS926_Assignment2.Images.crypto.jpg");
        }

        // search cryptos
        private async void OnSearchClicked(object sender, EventArgs e)
        {
            if (searchForCrypto.Text.Equals(""))
            {
                await DisplayAlert("Error", "Please enter a coin name to search!", "Ok");
            }
            else {
                await Navigation.PushAsync(new CoinDetailsPage(searchForCrypto.Text.ToLower()));
            }
        }

        // go to list of cryptos
        private async void OnBrowseListClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoinListPage());
        }

        // go to list of favourites
        private async void OnFavouritesListClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavouritesPage());
        }
    }
}
