using API.Models.Shallow.Primitives;

namespace API.Models.Lonely;

public class LonelyInfrastructure : ILonelyInfrastructure
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int MaxStudents { get; set; }

    public string ConfigurationFolder { get; set; }
}