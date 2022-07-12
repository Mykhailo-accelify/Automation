namespace DataAccess.Entities
{
    using DataAccess.Models.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class APIConstant : APIConstantBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new string Name { get; set; }
    }
}
