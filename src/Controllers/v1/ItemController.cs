using Microsoft.AspNetCore.Mvc;
using OrderApi.src.Application.Dtos.Item;
using OrderApi.src.Application.Interfaces;
using OrderApi.src.Application.Services;

namespace OrderApi.src.Controllers.V1;

[Route("api/v1/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemApplicationService _itemApplicationService;


    public ItemController(ItemApplicationService itemApplcationService)
    {
        _itemApplicationService = itemApplcationService;
        
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateItemRequestDto request)
    {
        try
        {
            var publicId = await _itemApplicationService.CreateAsync(request);

            return Created(string.Empty, new{ publicId });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

    

