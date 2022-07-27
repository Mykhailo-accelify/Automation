namespace API.Models.Old
{
    using DataAccess.Entities;
    using DataAccess.Models.Identified;

    public class ProductOneNested : Product
    {
        public new ICollection<ClientIdentified> Clients { get; set; }
    }
}
