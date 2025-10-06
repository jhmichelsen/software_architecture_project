using System.ComponentModel.DataAnnotations;

namespace Data;

public class FactoryEntity
{
    [Key]
    public int Id { get; set; }
    public string Location { get; set; }
}