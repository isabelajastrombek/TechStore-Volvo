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
                    quantity = 1,
                    insurance_value = 100
                }
            }
        };

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "me/shipment/calculate"
        );

        request.Content = new StringContent(
            JsonSerializer.Serialize(body),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _http.SendAsync(request);
        var raw = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Melhor Envio erro HTTP: {response.StatusCode} — {raw}");

        var doc = JsonDocument.Parse(raw);

        if (doc.RootElement.ValueKind != JsonValueKind.Array ||
            doc.RootElement.GetArrayLength() == 0)
            throw new Exception($"Nenhuma cotação retornada — {raw}");

 
        JsonElement? valid = null;

        foreach (var item in doc.RootElement.EnumerateArray())
        {
            if (!item.TryGetProperty("error", out _))
            {
                valid = item;
                break;
            }
        }

        if (valid == null)
            throw new Exception($"Todas as cotações retornaram erro — {raw}");

        var quote = valid.Value;
 
        decimal price = 0;

        if (quote.GetProperty("price").ValueKind == JsonValueKind.String)
            price = decimal.Parse(quote.GetProperty("price").GetString()!);
        else
            price = quote.GetProperty("price").GetDecimal();

        int deliveryDays = quote.TryGetProperty("delivery_time", out var dt) ? dt.GetInt32() : 0;

        string company = quote.TryGetProperty("company", out var comp) && comp.TryGetProperty("name", out var name) ? name.GetString()! : "Desconhecido";

        return new FreightResponseDto
        {
            Price = price,
            DeliveryDays = deliveryDays,
            Company = company
        };
    }


}
