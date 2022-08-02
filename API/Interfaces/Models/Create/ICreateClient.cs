using API.Interfaces.Models.Relationship.Create;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Interfaces.Models.Create
{
    public interface ICreateClient : IClientColumns, ICreateClientRelationships
    {
    }
}
