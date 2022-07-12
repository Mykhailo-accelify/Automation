namespace DataAccess.Entities
{
    using DataAccess.Models.Identified;
    using System.ComponentModel.DataAnnotations;

    public class Product : ProductIdentified
    {
        [StringLength(50)]
        public new string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
