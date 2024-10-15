using System.Collections.Generic;

using Vri.Domain.Models;

namespace Vri.Domain.Interfaces;

public interface IQuotesRepository
{
    IReadOnlyList<Quote> GetQuotesForIsin(string isin);
}