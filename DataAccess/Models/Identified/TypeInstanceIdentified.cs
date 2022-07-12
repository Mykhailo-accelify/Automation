namespace DataAccess.Models.Identified
{
    using DataAccess.Models.Base;

    public class TypeInstanceIdentified : TypeInstanceBase, IIdentified
    {
        public int Id { get; set; }
    }
}
