using API.Interfaces.Models.Create;
using API.Interfaces.Models.Relationship.Create;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Create;

public class CreateClient : ICreateClient
{
    public string Name { get; set; }

    public string Abbreviation { get; set; }

    public int AmountStudents { get; set; }

    public INamed State { get; set; }

    public ICollection<INamed>? Products { get; set; }

    public ICollection<INamed>? Infrastructures { get; set; }

}