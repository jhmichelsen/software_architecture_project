namespace Messaging.Contract;

public class WaterEvent
{
    public int FactoryId { get; set; }
    public int GreenHouseId { get; set; }
    public bool WaterOn { get; set; } = false;
}