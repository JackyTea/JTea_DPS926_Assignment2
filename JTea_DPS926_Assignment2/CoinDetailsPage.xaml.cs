﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JTea_DPS926_Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoinDetailsPage : ContentPage
    {
        // api networking service
        public NetworkingManager api = new NetworkingManager();

        // database service instance
        public DatabaseManager db = new DatabaseManager();

        // query parameter
        public string id { get; private set; }

        // coin data to be displayed
        public Coin coin { get; private set; }

        // constructor (1 params required)
        public CoinDetailsPage(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        // show long description up to certain length
        private string TruncateDescription(string description, int max)
        {
            if (description.Length > max)
                return description.Substring(0, max) + "...";
            return description;
        }

        // fetch coin data and render to ui
        private async void RenderCoinData()
        {
            coin = new Coin();
            var coinData = await api.getOneCoin(id);
            if (coinData.symbol is null)
            {
                CoinDetailsGrid.Children.Remove(addToFavouritesButton);
                coinSymbol.Text = "No Data";
                coinName.Text = "No Data";
                coinPrice.Text = "No Data";
                coinDescription.Text = "No coin was found!";
                CoinDetailsTitle.Text = "Coin not found!";
                await DisplayAlert("Error", id + " count not be found!", "Ok");
            }
            else
            {
                coin = coinData;
                coinSymbol.Text = coin.symbol.ToUpper();
                coinName.Text = coin.name;
                coinImage.Source = coin.image.large;
                coinPrice.Text = "$" + coin.market_data.current_price.usd.ToString();
                coinDescription.Text = TruncateDescription(coin.description.en, 200);
                CoinDetailsTitle.Text = coin.name + " Details";
            }
            loadingCrypto.IsRunning = false;
            CoinDetailsGrid.Children.Remove(loadingCrypto);
        }

        // determine ui state of favourites button
        private async void DetermineFavouritesButtonState()
        {
            bool exists = await db.CoinExists(coin.id);
            if (!exists)
            {
                addToFavouritesButton.Text = "Add to Favourites";
                addToFavouritesButton.BackgroundColor = Color.FromHex("#4287F5");
            }
            else
            {
                addToFavouritesButton.Text = "Remove from Favourites";
                addToFavouritesButton.BackgroundColor = Color.FromHex("#FF3421");
            }
        }

        // load in coin
        protected override void OnAppearing()
        {
            RenderCoinData();
            DetermineFavouritesButtonState();
            base.OnAppearing();
        }

        private async void OnAddToFavourites(object sender, EventArgs e)
        {
            bool exists = await db.CoinExists(coin.id);
            if (!exists)
            {
                addToFavouritesButton.Text = "Remove from Favourites";
                addToFavouritesButton.BackgroundColor = Color.FromHex("#FF3421");
                db.InsertCoin(coin);
                await DisplayAlert("Notice", "Succesfully added " + coin.id + " to favourites!", "Ok");
            }
            else
            {
                addToFavouritesButton.Text = "Add to Favourites";
                addToFavouritesButton.BackgroundColor = Color.FromHex("#4287F5");
                db.DeleteCoin(coin);
                await DisplayAlert("Notice", "Removed " + coin.id + " from favourites.", "Ok");
            }
        }
    }
}