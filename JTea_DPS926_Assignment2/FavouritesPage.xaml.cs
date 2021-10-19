using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JTea_DPS926_Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritesPage : ContentPage
    {
        // database service instance
        public DatabaseManager db = new DatabaseManager();

        // coins to be displayed
        public ObservableCollection<Coin> favouriteCoins { get; private set; }

        // constructor (0 params required)
        public FavouritesPage()
        {
            InitializeComponent();
        }

        // fetch coins from database
        private async void InitializeCoins()
        {
            favouriteCoins = new ObservableCollection<Coin>();
            favouriteCoins = await db.QueryAllCoins();
            if (favouriteCoins.Count == 0)
            {
                favouriteCoins = new ObservableCollection<Coin>();
            }
            loadingFavourites.IsRunning = false;
            favouritesListStackLayout.Children.Remove(loadingFavourites);
            listOfFavourites.ItemsSource = favouriteCoins;
        }

        // load in favourites
        protected override void OnAppearing()
        {
            InitializeCoins();
            base.OnAppearing();
        }

        // handle favourite tapped event
        private async void FavouriteListItemTapped(object sender, ItemTappedEventArgs e)
        {
            Coin c = e.Item as Coin;
            await Navigation.PushAsync(new FavouritesDetailsPage(c.id));
        }

        // handle tap and hold menu item to delete
        private void OnDeleteFavouriteMenuItemClicked(object sender, EventArgs e)
        {
            Coin c = (sender as MenuItem).CommandParameter as Coin;
            db.DeleteCoin(c);
            var toDelete = favouriteCoins.FirstOrDefault(x => x.id.Equals(c.id));
            int i = favouriteCoins.IndexOf(toDelete);
            favouriteCoins.RemoveAt(i);
        }
    }
}