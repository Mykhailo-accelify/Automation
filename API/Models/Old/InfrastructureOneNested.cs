namespace API.Models.Old
{
    using DataAccess.Entities;
    using DataAccess.Models.Identified;

    public class InfrastructureOneNested : InfrastructurePut
    {
        public TypeInfrastructureIdentified TypeInfrastructure { get; set; }

        public StateIdentified State { get; set; }
    }
}
