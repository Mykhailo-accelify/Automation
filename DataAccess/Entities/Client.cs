using DataAccess.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

[Table("Client")]
public class Client : IClient
{
    public int Id { get; set; }

    public int AmountStudents { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(50)]
    public string Abbreviation { get; set; }

    //[ForeignKey(nameof(ClientState))]
    //[Column(nameof(ClientStateId))]
    //public virtual int ClientStateId { get; set; }

    [Column(nameof(StateId))]
    public int StateId { get; set; }

    [ForeignKey(nameof(StateId))]
    public State State { get; set; }

    public ICollection<Product> Products { get; set; }

    public ICollection<Infrastructure> Infrastructures { get; set; }

    public virtual ICollection<Configuration> Configurations { get; set; }
}