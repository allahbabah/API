using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static project.Models.PriceModels;
using test1.Models;

namespace test1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetCryptoPrice : ControllerBase
    {


        private readonly ILogger<GetCryptoPrice> _logger;
        private readonly PriceClient _priceClient;

        public GetCryptoPrice(ILogger<GetCryptoPrice> logger, PriceClient priceClient)
        {
            _logger = logger;
            _priceClient = priceClient;

        }
        [HttpGet]

        public async Task<List<PriceModel>> GetProfit([FromQuery] Parameters parameters)
        {
            var price = await _priceClient.GetPrice(parameters.CryptoCurrency);
           
            return price;
        }
        [HttpGet("Markets")]

        public async Task<MarketModel> GetProfit1([FromQuery] Parameters parameters)
        {
            MarketModel result = new MarketModel();

            var price = await _priceClient.GetMaketPrice("binance", parameters.CryptoCurrency);
            result.PriceBinance = price.tickers[0].last;
            price = await _priceClient.GetMaketPrice("bybit_spot", parameters.CryptoCurrency);
            result.PriceBybit = price.tickers[0].last;
            price = await _priceClient.GetMaketPrice("gdax", parameters.CryptoCurrency);
            result.PriceCoinbase = price.tickers[0].last;
            price = await _priceClient.GetMaketPrice("kraken", parameters.CryptoCurrency);
            result.PriceKraken = price.tickers[0].last;
            price = await _priceClient.GetMaketPrice("ftx_spot", parameters.CryptoCurrency);
            result.PriceFTX = price.tickers[0].last;
            return result;
        }
        //public async Task<MarketModel> GetProfit1([FromQuery] Parameters parameters)
        //{
        //    MarketModel result = new MarketModel();

        //    var price = await _priceClient.GetMaketPrice(parameters.CryptoCurrency);
            
        //    return price;
        //}


    }
}
