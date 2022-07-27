using DataAccess.Models.Interfaces;

namespace DataAccess.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Product : IProduct
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
