using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace JTea_DPS926_Assignment2
{
    public partial class MainPage : ContentPage
    {
        public NetworkingService service = new NetworkingService();

        public ObservableCollection<Coin> coins { get; private set; }

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            coins = new ObservableCollection<Coin>();
            var coinsData = await service.getAllCoins();
            foreach (Coin c in coinsData)
            {
                coins.Add(
                    new Coin(
                        c.id,
                        c.symbol,
                        c.name,
                        c.image,
                        c.market_data,
                        new Description("")
                    )
                );
            }
            loadingCoins.IsRunning = false;
            listOfCoins.ItemsSource = coins;
            base.OnAppearing();
        }

        private async void listOfCoins_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Coin c = e.Item as Coin;
            await Navigation.PushAsync(new CoinDetailsPage(c.id));
        }
    }
}
