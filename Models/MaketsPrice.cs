using System.Collections.Generic;

namespace test1.Models
{
    public class MarcketPrice
    {
        public string name { get; set; }
        public List<Ticker> tickers { get; set; }
    }

    public class Ticker
    {

        public double last { get; set; }

    }
}
