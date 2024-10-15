using Microsoft.AspNetCore.Mvc;

using Vri.Domain.Interfaces;
using Vri.Domain.Repositories;
using Vri.Domain.Services;
using Vri.Frontend.ViewModels;

namespace Vri.Frontend.Controllers;

public class HomeController : Controller
{
    private readonly IQuotesRepository quotesRepository;

    public HomeController(IQuotesRepository quotesRepository)
    {
        this.quotesRepository = quotesRepository;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var positionRepo = new FakeTransactionRepository();
        var portfolioRepo = new PortfolioService(positionRepo);
        var portfolio = portfolioRepo.GetForUser(10000, "test1");
        var quotes = this.quotesRepository.GetQuotesForIsin("AEX");
            
        return View(new PortfolioViewModel(portfolio.Positions, portfolio.Balance, quotes));
    }
}