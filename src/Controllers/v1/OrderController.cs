using Microsoft.AspNetCore.Mvc;
using OrderApi.src.Application.Dtos.Order;
using OrderApi.src.Application.Dtos.Item;
using OrderApi.src.Application.Interfaces;

namespace OrderApi.src.Controllers.v1;

[Route("api/v1/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderApplicationService _orderApplicationService;

    public OrdersController(IOrderApplicationService orderApplicationService)
    {
        _orderApplicationService = orderApplicationService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequestDto requestDto)
    {
        try
        {
            var publicId = await _orderApplicationService.CreateAsync(requestDto);

            return Created(string.Empty, new{ publicId });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{orderPublicId:guid}/items/{itemPublicId:guid}")]
    public async Task<IActionResult> UpdateItemQuantity(
        [FromRoute] Guid orderPublicId, 
        [FromRoute] Guid itemPublicId,
        [FromBody] UpdateQuantityItemRequestDto requestDto)
    {
        try
        {
            await _orderApplicationService.UpdateItemQuantityAsync(orderPublicId, itemPublicId, requestDto.Quantity);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{orderPublicId}/items/{itemPublicId}")]
    public async Task<IActionResult> DeleteItem([FromRoute] Guid orderPublicId, [FromRoute] Guid itemPublicId){
        
        try
        {
            await _orderApplicationService.DeleteItemAsync(orderPublicId, itemPublicId);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{orderPublicId:guid}")]
    public IActionResult GetById([FromRoute] Guid orderPublicId)
    {
        try
        {
            var pedido = _orderApplicationService.GetByIdAsync(orderPublicId);

            return Ok(pedido);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

