using API.Interfaces.Models.Relationship.Shallow;
using API.Models.Shallow.Primitives;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Unidentified;

public class UnidentifiedClient : IClientColumns, IClientShallowRelationship
{
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public int AmountStudents { get; set; }
    public int StateId { get; set; }
    public ICollection<ILonelyProduct> Products { get; set; }
    public ICollection<ILonelyInfrastructure> Infrastructures { get; set; }
    public ILonelyState State { get; set; }
}