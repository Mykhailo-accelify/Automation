namespace DataAccess.Models.Identified
{
    using DataAccess.Models.Base;

    public class ProductIdentified : ProductBase, IIdentified
    {
        public int Id { get; set; }
    }
}
