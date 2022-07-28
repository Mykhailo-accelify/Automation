using API.Models.Shallow.Primitives;

namespace API.Models.Lonely;

public class LonelyClient : ILonelyClient
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Abbreviation { get; set; }

    public int AmountStudents { get; set; }
}