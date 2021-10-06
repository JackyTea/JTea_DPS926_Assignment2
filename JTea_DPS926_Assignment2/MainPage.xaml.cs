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
        NetworkingService service = new NetworkingService();
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
