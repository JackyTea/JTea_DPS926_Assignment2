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

        public string TruncateDescription(string description, int max)
        {
            if (description.Length > max)
                return description.Substring(0, max) + "...";
            return description;
        }

        protected async override void OnAppearing()
        {
            coin = new Coin();
            var coinData = await service.getOneCoin(id);
            if (coinData.symbol is null)
            {

            }
            else
            {
                coin = coinData;
                coinSymbol.Text = coin.symbol.ToUpper();
                coinName.Text = coin.name;
                coinImage.Source = coin.image.large;
                coinPrice.Text = coin.market_data.current_price.usd.ToString();
                coinDescription.Text = TruncateDescription(coin.description.en, 200);
            }
            base.OnAppearing();
        }
    }
}