namespace DataAccess.Entities;

using Models.Interfaces.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class APIConstant : IKeyValue
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public new string Name { get; set; }

    public string Value { get; set; }
}
