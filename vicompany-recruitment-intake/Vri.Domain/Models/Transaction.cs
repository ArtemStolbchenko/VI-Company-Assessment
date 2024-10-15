using System;

namespace Vri.Domain.Models;

public class Transaction
{
    public string Isin { get; set; }

    public decimal PricePerUnit { get; set; }

    public int Quantity { get; set; }

    public DateTime Executed { get; set; }

    public TransactionType Type { get; set; }
}