namespace API.Models
{
    using DataAccess.Models.Identified;

    public class InstanceOneNested : InstancePut
    {
        public TypeInstanceIdentified TypeInstance { get; set; }
    }
}
