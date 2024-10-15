using System;
using System.Collections.Generic;

using Vri.Domain.Interfaces;

namespace Vri.Domain.Repositories;

using Vri.Domain.Models;

/// <summary>
/// Todo: Should be replaced by data from https://tickly.vicompany.io/underlyings/{isin}
/// </summary>
public class DummyQuotesRepository : IQuotesRepository
{
    public IReadOnlyList<Quote> GetQuotesForIsin(string isin)
    {
        return new List<Quote>
        {
            new Quote(DateTime.Now.AddSeconds(-55), 0.31m),
            new Quote(DateTime.Now.AddSeconds(-55), 0.23m),
            new Quote(DateTime.Now.AddSeconds(-45), 0.37m),
            new Quote(DateTime.Now.AddSeconds(-35), 0.33m),
            new Quote(DateTime.Now.AddSeconds(-25), 0.31m),
            new Quote(DateTime.Now.AddSeconds(-15), 0.13m),
            new Quote(DateTime.Now.AddSeconds(-5), 0.31m),
            new Quote(DateTime.Now.AddSeconds(0), 0.13m)
        };
    }
}