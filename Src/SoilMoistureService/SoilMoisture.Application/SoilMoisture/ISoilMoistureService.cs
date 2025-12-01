using Domain;

namespace SoilMoisture.Application.SoilMoisture;

public interface ISoilMoistureService
{
    Task ProcessAsync(Factory factory);
}