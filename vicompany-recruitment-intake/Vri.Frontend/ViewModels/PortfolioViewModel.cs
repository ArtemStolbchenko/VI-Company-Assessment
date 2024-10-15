using System.Collections.Generic;

using Vri.Domain.Models;

namespace Vri.Frontend.ViewModels;

public class PortfolioViewModel
{ 
    public PortfolioViewModel(IReadOnlyList<Position> positions, decimal balance, IReadOnlyList<Quote> quotes)
    {
        this.Balance = balance;
        this.Positions = positions;
        this.Quotes = quotes;
    }

    public IReadOnlyList<Position> Positions { get; }

    public IReadOnlyList<Quote> Quotes { get; }

    public decimal Balance { get; }
}