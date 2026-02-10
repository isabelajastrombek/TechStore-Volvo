using Microsoft.EntityFrameworkCore;
using TechStore.Application.Interfaces;
using TechStore.Domain.Entities;
using TechStore.Infrastructure.Data;

namespace TechStore.Application.Services;

public class FreightService : IFreightService
{
    public Task<FreightResponseDto> CalculateAsync(FreightRequestDto dto)
    {
        var basePrice = 15m;
        var weightPrice = dto.WeightKg * 5m;

        return Task.FromResult(new FreightResponseDto
        {
            Price = basePrice + weightPrice,
            DeliveryDays = 5
        });
    }
}
