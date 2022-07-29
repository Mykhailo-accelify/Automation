using API.Interfaces.Models.Shallow;
using API.Models.Shallow.Primitives;

namespace API.Models.Shallow;

public class ShallowClient : IShallowClient
{
    public int Id { get; set; }
    public int AmountStudents { get; set; }
    public int StateId { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public ICollection<ILonelyProduct> Products { get; set; }
    public ICollection<ILonelyInfrastructure> Infrastructures { get; set; }
    public ILonelyState State { get; set; }
}