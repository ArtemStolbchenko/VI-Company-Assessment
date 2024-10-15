using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vri.Domain.Models
{
    public class TicklyQuotesDto
    { // used to process responses from tickly.vicompany.io
        public string Id { get; set; }

        public List<List<string>> Ticks { get; set; }

        public IReadOnlyList<Quote> ToQuotes()
        {
            var quotes = new List<Quote>();

            foreach (var ticklyQuote in this.Ticks)
            { // plain foreach loops should be faster than LINQ

                var timeStamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(ticklyQuote[0])).LocalDateTime; // local time just as at Tickle
                var tick = Convert.ToDecimal(ticklyQuote[1]); // second item is a tick

                var quote = new Quote(timeStamp, tick);
                quotes.Add(quote);
            }

            return quotes;
        }
    }
}
