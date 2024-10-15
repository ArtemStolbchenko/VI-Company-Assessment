using System;
using System.Collections.Generic;
using System.Linq;

namespace Vri.Domain.Models;

public class Portfolio
{
    public Portfolio(decimal startCash, IEnumerable<Transaction> transactions)
    {
        List<Transaction> transactionsList = transactions.ToList(); // prevent outer double enumeration

        // The logic and the values that Instruments and CashPosition depend on seem to be quite different
        // E.g., cash uses both types of transactions, while Instruments only use purchases 
        // Also separating the functions compliments the Single-responsibility principle
        this.CashPosition = startCash + CalculateCashPosition(transactionsList);
        this.Instruments = CountInstruments(transactionsList);
    }

    private decimal CalculateCashPosition(IEnumerable<Transaction> transactions)
    {
        try
        {
            decimal deltaCash = 0;
            foreach (Transaction transaction in transactions)
            {
                decimal transactionCost = transaction.Quantity * transaction.PricePerUnit;

                switch (transaction.Type)
                {
                    case TransactionType.Buy:
                        deltaCash -= transactionCost;
                        break;
                    case TransactionType.Sell:
                        deltaCash += transactionCost;
                        break;
                    default: // here in case if a new transaction type is ever added
                        throw new ArgumentException("Unknown transaction type!");
                }
            }

            return this.CashPosition += deltaCash;
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"Failed to calculate the cash position: {exception.Message}");
            return this.CashPosition;
        }
    }

    private List<Position> CountInstruments(IEnumerable<Transaction> transactions)
    {
        var positions = transactions.GroupBy(transaction => transaction.Isin)
            .Select((grouping) =>
            {
                // separated for readability
                var quantity = CalculateQuantity(grouping); 
                var averagePrice = CalculateAveragePrice(grouping);

                return new Position
                {
                    Isin = grouping.Key, // the Isin was used to create the grouping
                    Quantity = quantity,
                    Price = averagePrice
                };
            }).Where(position => position.Quantity != 0).ToList();

        return positions;
    }

    private int CalculateQuantity(IGrouping<string, Transaction> grouping)
    {
        try
        {
            var quantity = grouping.Sum(transaction =>
            {
                switch (transaction.Type)
                {
                    case TransactionType.Buy:
                        return transaction.Quantity;
                    case TransactionType.Sell:
                        return -transaction.Quantity;
                    default: // here in case if a new transaction type is ever added
                        throw new ArgumentException("Unknown transaction type!");
                }
            });
            return quantity;
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine($"Failed to calculate the quantity: {exception.Message}");
            return 0;
        }

    }

    private decimal CalculateAveragePrice(IGrouping<string, Transaction> grouping)
    {
        decimal averagePrice;

        // The task states "weighted average PURCHASE price"
        // So I am assuming that only TransactionType.Buy counts towards the average
        (int boughtAmount, decimal totalPrice) = grouping.Where(transaction => transaction.Type == TransactionType.Buy)
            .Select(transaction => (transaction.Quantity, (transaction.PricePerUnit * transaction.Quantity)))
            .Aggregate((0, 0m), (cumulative, next) =>
            {// Tuples allows to get both values in one query, should be good for performance
                cumulative.Item1 += next.Quantity;
                cumulative.Item2 += next.Item2;

                return cumulative;
            });

        averagePrice = totalPrice / boughtAmount;
        return averagePrice;
    }
    public decimal CashPosition { get; set; }

    public IReadOnlyList<Position> Instruments { get; set; } = new List<Position>(); 
}