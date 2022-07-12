namespace DataAccess.Models.Identified
{
    using DataAccess.Models.Base;

    public class StateIdentified : StateBase, IIdentified
    {
        public int Id { get; set; }
    }
}
