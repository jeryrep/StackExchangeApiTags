using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsRequest;
using StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsResponse;
using StackExchangeApiTags.Infrastructure.Interfaces;

namespace StackExchangeApiTags.Infrastructure.Services;

public class StackExchangeApiService : IStackExchangeApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<StackExchangeApiService> _logger;

    public StackExchangeApiService(IConfiguration configuration, ILogger<StackExchangeApiService> logger)
    {
        var handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip
        };
        _httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri(configuration.GetConnectionString("StackExchangeApi")!)
        };
        _logger = logger;
    }

    public async Task<IEnumerable<Tag>> GetPopularTagsFromApi(TagsOptions options)
    {
        var requestUri = $"/tags?fromdate={options.FromDate}&todate={options.ToDate}&page={options.Page}" +
                         $"&pagesize={options.PageSize}&order={options.Order}&min={options.Min}&max={options.Max}" +
                         $"&sort={options.Sort}&inname={options.InName}&site=stackoverflow";
        _logger.LogInformation($"Connecting to Stack Exchange API, request: {requestUri}");
        var response = await _httpClient.GetAsync(requestUri);
        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError($"Failed getting correct response: {response.StatusCode}");
            return new List<Tag>();
        }
        var content = await response.Content.ReadFromJsonAsync<TagsRoot>();
        _logger.LogInformation("Got correct response from Stack Exchange API");
        return content?.Items!;
    }
}