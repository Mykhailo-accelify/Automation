using API.Models.Shallow.Primitives;

namespace API.Models.Lonely;

public class LonelyState : ILonelyState
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Abbreviation { get; set; }
}