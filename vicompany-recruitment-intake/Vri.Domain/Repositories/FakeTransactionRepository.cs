using System;
using System.Collections.Generic;

using Vri.Domain.Models;

namespace Vri.Domain.Repositories;

/// <summary>
/// This imitates a database
/// </summary>
public class FakeTransactionRepository
{ 
    public IEnumerable<Transaction> TransactionFromUser(string userIdentifier)
    {
        if (userIdentifier == "test1")
        {
            yield return new Transaction { Quantity = 2, Isin = "US88579Y1010", Executed = new DateTime(2015, 12, 1), PricePerUnit = 123.1m, Type = TransactionType.Buy };
            yield return new Transaction { Quantity = 23, Isin = "US88579Y1010", Executed = new DateTime(2015, 12, 2), PricePerUnit = 123.45m, Type = TransactionType.Buy };
            yield return new Transaction { Quantity = 123, Isin = "AU000000LIT3", Executed = new DateTime(2015, 12, 1), PricePerUnit = 12, Type = TransactionType.Buy };
            yield return new Transaction { Quantity = 1, Isin = "AU000000LIT3", Executed = new DateTime(2016, 12, 1), PricePerUnit = 3, Type = TransactionType.Sell };
            yield return new Transaction { Quantity = 8, Isin = "US88579Y1010", Executed = new DateTime(2017, 5, 3), PricePerUnit = 142, Type = TransactionType.Sell };
            yield return new Transaction { Quantity = 2, Isin = "US88579Y1010", Executed = new DateTime(2018, 3, 1), PricePerUnit = 80.1m, Type = TransactionType.Buy };
            yield return new Transaction { Quantity = 5, Isin = "US88579Y1010", Executed = new DateTime(2018, 5, 1), PricePerUnit = 93.41m, Type = TransactionType.Buy };
            yield return new Transaction { Quantity = 11, Isin = "US88579Y1010", Executed = new DateTime(2018, 7, 21), PricePerUnit = 111.0m, Type = TransactionType.Buy };
            yield return new Transaction { Quantity = 2, Isin = "NL0000009165", Executed = new DateTime(2015, 12, 1), PricePerUnit = 15, Type = TransactionType.Buy };
            yield return new Transaction { Quantity = 1, Isin = "NL0000009165", Executed = new DateTime(2016, 12, 1), PricePerUnit = 10, Type = TransactionType.Sell };
            yield return new Transaction { Quantity = 1, Isin = "NL0000009165", Executed = new DateTime(2016, 12, 1), PricePerUnit = 20, Type = TransactionType.Sell };
        }
        else if (userIdentifier == "test2")
        {
            yield return new Transaction { Quantity = 23, Isin = "US88579Y1010", Executed = new DateTime(2015, 12, 1), PricePerUnit = 123.1m, Type = TransactionType.Buy };
            yield return new Transaction { Quantity = 9, Isin = "AU000000LIT3", Executed = new DateTime(2015, 12, 1), PricePerUnit = 12, Type = TransactionType.Buy };
            yield return new Transaction { Quantity = 9, Isin = "AU000000LIT3", Executed = new DateTime(2016, 12, 1), PricePerUnit = 13, Type = TransactionType.Sell };
        }
    }
}