using TechStore.Application.DTOs;

namespace TechStore.Application.Interfaces;

public interface IFreightService
{
    Task<FreightResponseDto> CalculateAsync(FreightRequestDto dto);
}