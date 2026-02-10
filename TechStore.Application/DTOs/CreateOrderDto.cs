namespace TechStore.Application.DTOs;

public class CreateOrderDto
{
    public int ClientId { get; set; }
    public int AddressId { get; set; }
    public int CardId { get; set; }

    public List<CreateOrderItemDto> Items { get; set; } = new();
}
