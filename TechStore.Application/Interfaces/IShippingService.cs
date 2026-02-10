public interface IShippingService
{
    Task<decimal> CalculateShippingAsync(string cep, decimal totalWeight);
}
