using System;

namespace Vri.Domain.Models;

public class Quote
{
    public Quote(DateTime date, decimal rate)
    {
        this.Date = date;
        this.Rate = rate;
    }

    public DateTime Date { get; }

    public decimal Rate { get; }
}