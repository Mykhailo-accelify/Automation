using API.Interfaces.Models.Relationship.Create;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Create;

public class CreateProduct : IProductColumns, ICreateProductRelationships
{
    public string Name { get; set; }

    public ICollection<INamed> Clients { get; set; }
}