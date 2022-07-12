namespace DataAccess.Entities
{
    using DataAccess.Models.Base;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class InfrastructureVariable : InfrastructureVariableBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new string Name { get; set; }

        public Infrastructure Infrastructure { get; set; }
    }
}
