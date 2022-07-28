using API.Interfaces.Models.Relationship.Create;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Create;

public class CreateInstance : IInstanceColumns, ICreateInstanceRelationships
{
    public string Name { get; set; }

    public string Endpoint { get; set; }

    public string Secret { get; set; }

    public INamed TypeInstance { get; set; }

    public ICollection<INamed> Infrastructures { get; set; }

}