using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsRequest;
using StackExchangeApiTags.Infrastructure.Interfaces;

namespace StackExchangeApiTags.Tests;

[TestClass]
public class StackExchangeApiServiceUnitTests
{
    private readonly IStackExchangeApiService _stackExchangeApiService;
    public StackExchangeApiServiceUnitTests()
    {
        var webHost = WebHost.CreateDefaultBuilder()
            .UseStartup<Program>()
            .Build();
        _stackExchangeApiService = webHost.Services.GetService<IStackExchangeApiService>()!;
    }

    [TestMethod]
    public async Task TestMethod1()
    {
        var list = await _stackExchangeApiService.GetPopularTagsFromApi(new TagsOptions
        {
            Page = 1,
            PageSize = 30,
        });
        Assert.IsNotNull(list);
        Assert.AreEqual(30, list.Count());
    }
}