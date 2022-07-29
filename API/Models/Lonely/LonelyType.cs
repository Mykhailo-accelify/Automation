using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Lonely
{
    public class LonelyType : IType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
