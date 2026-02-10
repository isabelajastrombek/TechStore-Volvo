public class FreightRequestDto
{
    public string FromZipCode { get; set; } = null!;
    public string ToZipCode { get; set; } = null!;
    public decimal WeightKg { get; set; }
}
