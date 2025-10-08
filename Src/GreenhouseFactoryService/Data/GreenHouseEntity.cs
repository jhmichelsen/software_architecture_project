using System.ComponentModel.DataAnnotations;

namespace Data;

public class GreenHouseEntity
{
    [Key]
    public int Id { get; set; }

    public bool WaterOn { get; set; }
}