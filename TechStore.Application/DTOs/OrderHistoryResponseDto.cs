public class OrderHistoryResponseDto
{
public int IdOrder { get; set; }
    public DateTime? DateOrder { get; set; }
    public required string StatusOrder { get; set; }
    public decimal? TotalPrice { get; set; }
    public decimal? TotalShipping { get; set; }
    public string CouponCode { get; set; } = string.Empty;
    public List<OrderItemHistoryDto>? Items { get; set; }
}