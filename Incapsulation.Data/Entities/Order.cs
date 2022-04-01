namespace Incapsulation.Data.Entities;

public class Order : IEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public Customer Customer { get; set; }
}
