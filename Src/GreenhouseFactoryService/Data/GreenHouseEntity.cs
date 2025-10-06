using System.ComponentModel.DataAnnotations;

namespace Data;

public class GreenHouseEntity
{
    [Key]
    public int Id { get; set; }

    public int FactoryEntityId { get; set; }
    public FactoryEntity FactoryEntity { get; set; }
}