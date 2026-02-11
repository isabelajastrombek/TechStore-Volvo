using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TechStore.Application.DTOs;
using TechStore.Application.Interfaces;
using System.Globalization;


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
                    quantity = 1,
                    insurance_value = 100
                }
            }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, "me/shipment/calculate")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(body),
                Encoding.UTF8,
                "application/json")
        };

        var response = await _http.SendAsync(request);
        var raw = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Melhor Envio erro: {response.StatusCode} — {raw}");

        using var doc = JsonDocument.Parse(raw);

        var quote = doc.RootElement
            .EnumerateArray()
            .FirstOrDefault(x => !x.TryGetProperty("error", out _));

        // sandbox pode não retornar serviço válido
        if (quote.ValueKind == JsonValueKind.Undefined)
        {
            return new FreightResponseDto
            {
                Price = 29.90m,
                DeliveryDays = 5,
                Company = "Sandbox Mock"
            };
        }

        var price = quote.GetProperty("price").ValueKind == JsonValueKind.String
            ? decimal.Parse(quote.GetProperty("price").GetString()!, CultureInfo.InvariantCulture)
            : quote.GetProperty("price").GetDecimal();

        var days = quote.GetProperty("delivery_time").GetInt32();

        var company = quote
            .GetProperty("company")
            .GetProperty("name")
            .GetString()!;

        return new FreightResponseDto
        {
            Price = price,
            DeliveryDays = days,
            Company = company
        };
    }



}
