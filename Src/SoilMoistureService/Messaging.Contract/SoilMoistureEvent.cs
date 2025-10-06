namespace Messaging.Contract;

public class SoilMoistureEvent
{
    public int FactoryId { get; set; }
    public int GreenHouseId { get; set; }
    public int SolMoisturePercentage { get; set; }
}