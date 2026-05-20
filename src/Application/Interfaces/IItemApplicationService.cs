using OrderApi.src.Application.Dtos.Item;

namespace OrderApi.src.Application.Interfaces;

public interface IItemApplicationService
{
    Task<Guid> CreateAsync(CreateItemRequestDto item);
}