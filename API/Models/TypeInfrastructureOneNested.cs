namespace API.Models
{
    using DataAccess.Entities;
    using DataAccess.Models.Identified;

    public class TypeInfrastructureOneNested : TypeInfrastructure
    {
        public new ICollection<InfrastructureIdentified> Infrastructures { get; set; }
    }
}
