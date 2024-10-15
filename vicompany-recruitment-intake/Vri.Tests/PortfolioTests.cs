using System;
using System.Collections.Generic;

using Shouldly;

using Vri.Domain.Models;

using Xunit;

namespace Vri.Tests;

public class PortfolioTests
{
    [Fact]
    public void Instruments_ForSet1_TwoInstruments()
    {
        // Arrange
        var transactions = GetTransactionSet1();

        // Act
        var result = new Portfolio(0, transactions);

        // Assert
        result.Instruments.Count.ShouldBe(2);
    }

    [Fact]
    public void Instruments_ForSet2_OneInstruments()
    {
        // Arrange
        var transactions = GetTransactionSet2();

        // Act
        var result = new Portfolio(0, transactions);

        // Assert
        result.Instruments.Count.ShouldBe(1);
    }

    [Fact]
    public void Instruments_ForSet1_PositionUs88579Y1010ShouldBe35For114dot7395()
    {
        // Arrange
        var transactions = GetTransactionSet1();

        // Act
        var result = new Portfolio(0, transactions);

        // Assert 
        result.Instruments[0].Isin.ShouldBe("US88579Y1010");
        result.Instruments[0].Price.ShouldBeInRange(114.7395m, 114.7396m);
        result.Instruments[0].Quantity.ShouldBe(35);
    }

    [Fact]
    public void Instruments_ForSet2_PositionUs88579Y1010ShouldBe23For123dot1()
    {
        // Arrange
        var transactions = GetTransactionSet2();

        // Act
        var result = new Portfolio(0, transactions);

        // Assert 
        result.Instruments.Count.ShouldBe(1);
        result.Instruments[0].Isin.ShouldBe("US88579Y1010");
        result.Instruments[0].Price.ShouldBe(123.1m);
        result.Instruments[0].Quantity.ShouldBe(23);
    }

    [Fact]
    public void CashPosition_ForSet1WithStartCash10000_ResultIs4729dot2()
    {
        // Arrange
        var transactions = GetTransactionSet1();

        // Act
        var result = new Portfolio(10000, transactions);

        // Assert
        result.CashPosition.ShouldBe(4729.2m);
    }

    [Fact]
    public void CashPosition_ForSet2WithStartCash10000_ResultIs7177dot7()
    {
        // Arrange
        var transactions = GetTransactionSet2();

        // Act
        var result = new Portfolio(10000, transactions);

        // Assert
        result.CashPosition.ShouldBe(7177.7m);
    }

    private IEnumerable<Transaction> GetTransactionSet1()
    {
        yield return new Transaction
        {
            Quantity = 2,
            Isin = "US88579Y1010",
            Executed = new DateTime(2015, 12, 1),
            PricePerUnit = 123.1m,
            Type = TransactionType.Buy
        };
        yield return new Transaction
        {
            Quantity = 23,
            Isin = "US88579Y1010",
            Executed = new DateTime(2015, 12, 2),
            PricePerUnit = 123.45m,
            Type = TransactionType.Buy
        };
        yield return new Transaction
        {
            Quantity = 123,
            Isin = "AU000000LIT3",
            Executed = new DateTime(2015, 12, 1),
            PricePerUnit = 12,
            Type = TransactionType.Buy
        };
        yield return new Transaction
        {
            Quantity = 1,
            Isin = "AU000000LIT3",
            Executed = new DateTime(2016, 12, 1),
            PricePerUnit = 3,
            Type = TransactionType.Sell
        };
        yield return new Transaction
        {
            Quantity = 8,
            Isin = "US88579Y1010",
            Executed = new DateTime(2017, 5, 3),
            PricePerUnit = 142,
            Type = TransactionType.Sell
        };
        yield return new Transaction
        {
            Quantity = 2,
            Isin = "US88579Y1010",
            Executed = new DateTime(2018, 3, 1),
            PricePerUnit = 80.1m,
            Type = TransactionType.Buy
        };
        yield return new Transaction
        {
            Quantity = 5,
            Isin = "US88579Y1010",
            Executed = new DateTime(2018, 5, 1),
            PricePerUnit = 93.41m,
            Type = TransactionType.Buy
        };
        yield return new Transaction
        {
            Quantity = 11,
            Isin = "US88579Y1010",
            Executed = new DateTime(2018, 7, 21),
            PricePerUnit = 111.0m,
            Type = TransactionType.Buy
        };
        yield return new Transaction
        {
            Quantity = 2,
            Isin = "NL0000009165",
            Executed = new DateTime(2015, 12, 1),
            PricePerUnit = 15,
            Type = TransactionType.Buy
        };
        yield return new Transaction
        {
            Quantity = 1,
            Isin = "NL0000009165",
            Executed = new DateTime(2016, 12, 1),
            PricePerUnit = 10,
            Type = TransactionType.Sell
        };
        yield return new Transaction
        {
            Quantity = 1,
            Isin = "NL0000009165",
            Executed = new DateTime(2016, 12, 1),
            PricePerUnit = 20,
            Type = TransactionType.Sell
        };
    }

    private IEnumerable<Transaction> GetTransactionSet2()
    {
        yield return new Transaction()
        {
            Quantity = 23,
            Isin = "US88579Y1010",
            Executed = new DateTime(2015, 12, 1),
            PricePerUnit = 123.1m,
            Type = TransactionType.Buy
        };
        yield return new Transaction()
        {
            Quantity = 9,
            Isin = "AU000000LIT3",
            Executed = new DateTime(2015, 12, 1),
            PricePerUnit = 12,
            Type = TransactionType.Buy
        };
        yield return new Transaction()
        {
            Quantity = 9,
            Isin = "AU000000LIT3",
            Executed = new DateTime(2016, 12, 1),
            PricePerUnit = 13,
            Type = TransactionType.Sell
        };
    }
}