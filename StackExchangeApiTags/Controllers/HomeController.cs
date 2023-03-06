using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StackExchangeApiTags.Infrastructure.Interfaces;
using StackExchangeApiTags.Models;

namespace StackExchangeApiTags.Controllers;

public class HomeController : Controller
{
    private readonly ICalculationService _calculationService;
    private readonly IStackExchangeTagsService _stackExchangeTagsService;

    public HomeController(IStackExchangeTagsService stackExchangeTagsService,
        ICalculationService calculationService)
    {
        _stackExchangeTagsService = stackExchangeTagsService;
        _calculationService = calculationService;
    }

    public async Task<IActionResult> Index()
    {
        const uint count = 1000;
        var tags = (await _stackExchangeTagsService.GetPopularTags(count)).ToList();
        return View(new TagsViewModel(_calculationService.GetTagsWithCalculatedShare(tags)));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}