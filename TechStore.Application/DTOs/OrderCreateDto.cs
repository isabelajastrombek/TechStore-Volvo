public class OrderCreateDto
{
    public int ClientId { get; set; }
    public int CardId { get; set; }
    public int AddressId { get; set; } 
    
    public string? CouponCode { get; set; } 
    public List<OrderItemCreateDto> Items { get; set; } = new();
}