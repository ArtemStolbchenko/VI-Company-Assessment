using Vri.Domain.Models;
using Vri.Domain.Repositories;

namespace Vri.Domain.Services;

public class PortfolioService
{
    private readonly FakeTransactionRepository positionRepository;

    public PortfolioService(FakeTransactionRepository positionRepository)
    {
        this.positionRepository = positionRepository;
    }

    public Portfolio GetForUser(decimal startCash, string userIdentifier)
    {
        var transactions = this.positionRepository.TransactionFromUser(userIdentifier);
 
        return new Portfolio(startCash, transactions);
    }
}