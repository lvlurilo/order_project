using OrderApi.src.Application.Dtos.Item;
using OrderApi.src.Application.Interfaces;

namespace OrderApi.src.Application.Services;

public class ItemApplicationService : IItemApplicationService
{
    public Task<Guid> CreateAsync(CreateItemRequestDto item)
    {
        throw new NotImplementedException();
    }
}