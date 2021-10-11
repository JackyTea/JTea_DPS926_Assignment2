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
    public partial class CoinListPage : ContentPage
    {
        // api service instance
        public NetworkingService service = new NetworkingService();

        // coins to be displayed
        public ObservableCollection<Coin> coins { get; private set; }

        // constructor (0 params required)
        public CoinListPage()
        {
            InitializeComponent();
        }

        // load in coins
        protected async override void OnAppearing()
        {
            coins = new ObservableCollection<Coin>();
            var coinsData = await service.getAllCoins();
            if (coinsData.Count != 0)
            {
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
                loadingCryptos.IsRunning = false;
                coinListStackLayout.Children.Remove(loadingCryptos);
                listOfCryptos.ItemsSource = coins;
            }
            else {
                Label noCoinsMessage = new Label();
                noCoinsMessage.Text = "Unable to load data!";
                noCoinsMessage.FontSize = 30;
                noCoinsMessage.TextColor = Color.Black;
                noCoinsMessage.HorizontalOptions = LayoutOptions.Center;
                coinListStackLayout.Children.Remove(loadingCryptos);
                coinListStackLayout.Children.Add(noCoinsMessage);
            }
            base.OnAppearing();
        }

        // handle coin in list tapped event
        private async void CoinListItemTapped(object sender, ItemTappedEventArgs e)
        {
            Coin c = e.Item as Coin;
            await Navigation.PushAsync(new CoinDetailsPage(c.id));
        }
    }
}