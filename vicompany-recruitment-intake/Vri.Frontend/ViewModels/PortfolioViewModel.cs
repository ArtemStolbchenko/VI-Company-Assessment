using System.Collections.Generic;

using Vri.Domain.Models;

namespace Vri.Frontend.ViewModels;

public class PortfolioViewModel
{ 
    public PortfolioViewModel(IReadOnlyList<Position> positions, decimal cashPosition, IReadOnlyList<Quote> quotes)
    {
        this.CashPosition = cashPosition;
        this.Positions = positions;
        this.Quotes = quotes;
    }

    public IReadOnlyList<Position> Positions { get; }

    //Either I'm missing finance-related knowledge, or the connection between "Quotes" and "AEX" is non-trivial
    public IReadOnlyList<Quote> Quotes { get; }

    public decimal CashPosition { get; }
}