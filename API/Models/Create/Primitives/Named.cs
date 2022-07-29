using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Create.Primitives;

public class Named : INamed
{
    public string Name { get; set; }
}