namespace API.Models
{
    using DataAccess.Models.Identified;

    public class ClientPut : ClientIdentified
    {
        public StateIdentified State { get; set; }
    }
}
