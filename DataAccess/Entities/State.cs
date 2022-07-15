using DataAccess.Models.Interfaces;

namespace DataAccess.Entities;

public class State : IState
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Abbreviation { get; set; }
    
    public ICollection<Client> Clients { get; set; }
}