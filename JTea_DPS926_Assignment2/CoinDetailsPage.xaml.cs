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
    public partial class CoinDetailsPage : ContentPage
    {
        public NetworkingService service = new NetworkingService();

        public string id { get; private set; }

        public Coin coin { get; private set; }

        public CoinDetailsPage(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            coin = new Coin();
            var coinData = await service.getOneCoin(id);
            coin = coinData;
            coinId.Text = coin.id;
            base.OnAppearing();
        }
    }
}