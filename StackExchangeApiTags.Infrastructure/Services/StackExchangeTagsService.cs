using System.ComponentModel.DataAnnotations;
using StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsRequest;
using StackExchangeApiTags.Infrastructure.DataTransferObjects.StackExchangeApi.TagsResponse;
using StackExchangeApiTags.Infrastructure.Interfaces;

namespace StackExchangeApiTags.Infrastructure.Services;

public class StackExchangeTagsService : IStackExchangeTagsService
{
    private readonly IStackExchangeApiService _stackExchangeApiService;

    public StackExchangeTagsService(IStackExchangeApiService stackExchangeApiService)
    {
        _stackExchangeApiService = stackExchangeApiService;
    }

    public async Task<IEnumerable<Tag>> GetPopularTags([Range(1, uint.MaxValue)]uint count)
    {
        var tags = new List<Tag>();
        var i = 1;
        if (count >= 100)
        {
            for (; i <= count / 100; i++)
            {
                tags.AddRange(await _stackExchangeApiService.GetPopularTagsFromApi(new TagsOptions
                {
                    Page = i,
                    PageSize = 100
                }));
            }
        }

        var remainder = (byte)(count % 100);
        if (remainder > 0)
        {
            tags.AddRange(await _stackExchangeApiService.GetPopularTagsFromApi(new TagsOptions
            {
                PageSize = remainder,
                Page = i
            }));
        }
        
        return tags;
    }
}