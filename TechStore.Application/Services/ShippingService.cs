using System.Net.Http.Json;

namespace TechStore.Application.Services;

public class ShippingService : IShippingService
{
    private readonly HttpClient _httpClient;

    public ShippingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> CalculateShippingAsync(string cep, decimal totalWeight)
    {
        var response = await _httpClient.GetAsync($"https://brasilapi.com.br/api/cep/v1/{cep}");

        if (response.IsSuccessStatusCode)
        {
            var location = await response.Content.ReadFromJsonAsync<CepResponseDto>();
            string uf = location.State.ToUpper();

            
            decimal BasePrice;

            if (uf == "PR")
            {
                BasePrice = 15.00m;
            }
            else if (uf == "SP" || uf == "SC" || uf == "RS")
            {
                BasePrice = 25.00m;
            }
            else if (uf == "RJ" || uf == "MG" || uf == "ES")
            {
                BasePrice = 30.00m;
            }
            else if (uf == "MT" || uf == "MS" || uf == "GO" || uf == "DF")
            {
                BasePrice = 40.00m;
            }
            else
            {
                BasePrice = 55.00m;
            }

            decimal WeightFee = totalWeight * 2.50m;
            return BasePrice + WeightFee;
        }

        return 35.00m; 
    }
}