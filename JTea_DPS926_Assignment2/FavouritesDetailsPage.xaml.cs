using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JTea_DPS926_Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritesDetailsPage : ContentPage
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
        public FavouritesDetailsPage(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        // show long description up to certain length
        public string TruncateDescription(string description, int max)
        {
            if (description.Length > max)
                return description.Substring(0, max) + "...";
            return description;
        }

        // get favourites data
        private async void GetFavouritesData()
        {
            coin = new Coin();
            var coinData = await api.getOneCoin(id);
            if (coinData.symbol is null)
            {
                FavouriteDetailsGrid.Children.Remove(removeFromFavouritesButton);
                favouriteSymbol.Text = "No Data";
                favouriteName.Text = "No Data";
                favouritePrice.Text = "No Data";
                favouriteDescription.Text = "No coin was found!";
                FavouriteDetailsTitle.Text = "Coin not found!";
                await DisplayAlert("Error", id + " count not be found!", "Ok");
            }
            else
            {
                coin = coinData;
                favouriteSymbol.Text = coin.symbol.ToUpper();
                favouriteName.Text = coin.name;
                favouriteImage.Source = coin.image.large;
                favouritePrice.Text = "$" + coin.market_data.current_price.usd.ToString();
                favouriteDescription.Text = TruncateDescription(coin.description.en, 200);
                FavouriteDetailsTitle.Text = coin.name + " (Favourited)";
            }
            loadingFavourite.IsRunning = false;
            FavouriteDetailsGrid.Children.Remove(loadingFavourite);
        }

        // load in favourites
        protected override void OnAppearing()
        {
            GetFavouritesData();
            base.OnAppearing();
        }

        // handle updating the current favourite
        private async void OnUpdateFavourite(object sender, EventArgs e)
        {
            if (updateFavourite.Text.Equals(""))
            {
                await DisplayAlert("Error", "Cannot enter an empty field!", "Ok");
            }
            else
            {
                var coinData = await api.getOneCoin(updateFavourite.Text.ToLower());
                if (coinData.symbol is null)
                {
                    await DisplayAlert("Error", updateFavourite.Text + " is not a valid coin.", "Ok");
                }
                else
                {
                    Coin c = coin;
                    db.DeleteCoin(coin);
                    coin = coinData;
                    db.InsertCoin(coin);
                    await Navigation.PopAsync();
                    await DisplayAlert("Notice", "Updated " + c.id + " to " + coin.id, "Ok");
                }
            }
        }

        // handle removing the current favourite
        private async void OnRemoveFromFavourites(object sender, EventArgs e)
        {
            Coin c = coin;
            db.DeleteCoin(coin);
            await Navigation.PopAsync();
            await DisplayAlert("Notice", "Removed " + c.id + " from favourites.", "Ok");
        }
    }
}