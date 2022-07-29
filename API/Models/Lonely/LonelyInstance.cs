using API.Models.Shallow.Primitives;

namespace API.Models.Lonely;

public class LonelyInstance : ILonelyInstance
{
    public int Id { get; set; }
    public string Endpoint { get; set; }
    public string Secret { get; set; }
    public string Name { get; set; }
}