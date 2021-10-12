using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JTea_DPS926_Assignment2
{
    public class NetworkingManager
    {
        // api endpoint
        private string url = "https://api.coingecko.com/api/v3/coins/";

        // client to contact webservice
        HttpClient client = new HttpClient();

        // default constructor (0 params required)
        public NetworkingManager() { }

        // get all coins available
        public async Task<List<Coin>> getAllCoins()
        {
            var response = await client.GetAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<Coin>();
            }
            else
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                var coinsData = JsonConvert.DeserializeObject<List<Coin>>(jsonStr);
                return coinsData;
            }
        }

        // get a certain coin
        public async Task<Coin> getOneCoin(string id)
        {
            var response = await client.GetAsync(url + id);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new Coin();
            }
            else
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                var coinData = JsonConvert.DeserializeObject<Coin>(jsonStr);
                return coinData;
            }
        }
    }
}
