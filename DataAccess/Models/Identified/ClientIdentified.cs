namespace DataAccess.Models.Identified
{
    using DataAccess.Models.Base;

    public class ClientIdentified : ClientBase, IIdentified
    {
        public int Id { get; set; }
    }
}
