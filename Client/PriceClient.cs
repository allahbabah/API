using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static project.Models.PriceModels;
using test1.Models;


namespace project.Client
{
    public class PriceClient
    {
        public static string[] Markets = new string[] { "binance", "bybit_spot", "gdax", "kraken", "ftx_spot" };
        HttpClient client;
        private static string Adress;

        public PriceClient()
        {
            Adress = Constants.adress;
            client = new HttpClient();
            client.BaseAddress = new Uri(Adress);

        }
        public async Task<List<PriceModel>> GetPrice(string cryptoCurrency)
        {
            var respoce = await client.GetAsync($"/api/v3/coins/markets?vs_currency=usd&ids={cryptoCurrency}");
            var content = respoce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<PriceModel>>(content);
            //var result = (List<PriceModel>)JsonConvert.DeserializeObject();
            result[0].Current_price = 50000;
            return result;
        }
        public async Task<MarcketPrice> GetMaketPrice(string market, string cryptoCurrency)
        {

            var responce = await client.GetAsync($"/api/v3/exchanges/{market}/tickers?coin_ids={cryptoCurrency}");
            var content = responce.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<MarcketPrice>(content);
            return result;
        }
        //public async Task<MarketModel> GetMaketPrice(string cryptoCurrency)
        //{
        //    MarketModel result = new MarketModel();
        //    var responce = await client.GetAsync($"/api/v3/exchanges/binance/tickers?coin_ids={cryptoCurrency}");
        //    var content = responce.Content.ReadAsStringAsync().Result;
        //    var tempResult = JsonConvert.DeserializeObject<MarcketPrice>(content);
        //    result.PriceBinance = tempResult.tickers[0].last;
        //    responce = await client.GetAsync($"/api/v3/exchanges/bybit_spot/tickers?coin_ids={cryptoCurrency}");
        //    content = responce.Content.ReadAsStringAsync().Result;
        //    tempResult = JsonConvert.DeserializeObject<MarcketPrice>(content);
        //    result.PriceBybit = tempResult.tickers[0].last;
        //    responce = await client.GetAsync($"/api/v3/exchanges/gdax/tickers?coin_ids={cryptoCurrency}");
        //    content = responce.Content.ReadAsStringAsync().Result;
        //    tempResult = JsonConvert.DeserializeObject<MarcketPrice>(content);
        //    result.PriceCoinbase = tempResult.tickers[0].last;
        //    responce = await client.GetAsync($"/api/v3/exchanges/kraken/tickers?coin_ids={cryptoCurrency}");
        //    content = responce.Content.ReadAsStringAsync().Result;
        //    tempResult = JsonConvert.DeserializeObject<MarcketPrice>(content);
        //    result.PriceKraken = tempResult.tickers[0].last;
        //    responce = await client.GetAsync($"/api/v3/exchanges/ftx_spot/tickers?coin_ids={cryptoCurrency}");
        //    content = responce.Content.ReadAsStringAsync().Result;
        //    tempResult = JsonConvert.DeserializeObject<MarcketPrice>(content);
        //    result.PriceFTX = tempResult.tickers[0].last;

        //    return result;
        //}

    }
}
