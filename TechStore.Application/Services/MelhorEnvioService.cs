using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TechStore.Application.DTOs;
using TechStore.Application.Interfaces;

namespace TechStore.Application.Services;

public class MelhorEnvioService : IFreightService
{
    private readonly HttpClient _http;

    public MelhorEnvioService(HttpClient http)
    {
        _http = http;
    }

    public async Task<FreightResponseDto> CalculateAsync(FreightRequestDto dto)
    {
        var body = new
        {
            from = new { postal_code = dto.FromZipCode },
            to = new { postal_code = dto.ToZipCode },
            products = new[]
            {
                new
                {
                    weight = dto.WeightKg,
                    width = 15,
                    height = 10,
                    length = 20,
                    quantity = 1
                }
            }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, "api/v2/me/shipment/calculate");
        request.Content = new StringContent(
            JsonSerializer.Serialize(body),
            Encoding.UTF8,
            "application/json"
        );

        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", "SEU_TOKEN_AQUI");

        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var data = JsonDocument.Parse(json);

        var cheapest = data.RootElement[0];

        return new FreightResponseDto
        {
            Price = cheapest.GetProperty("price").GetDecimal(),
            DeliveryDays = cheapest.GetProperty("delivery_time").GetInt32(),
            Company = cheapest.GetProperty("company").GetProperty("name").GetString()!
        };
    }
}
