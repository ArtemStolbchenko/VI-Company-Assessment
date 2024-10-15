using System.Collections.Generic;

namespace Vri.Domain.Models;

public class Portfolio
{
    public Portfolio(decimal startCash, IEnumerable<Transaction> transactions)
    {
        // TODO: implement
    }

    public decimal CashPosition { get; set; }

    public IReadOnlyList<Position> Instruments { get; set; } = new List<Position>(); 
}