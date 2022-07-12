namespace DataAccess.Models.Base
{
    public class InstanceBase
    {
        public virtual string Name { get; set; }

        public string Endpoint { get; set; }

        public string Secret { get; set; }

        public int TypeInstanceId { get; set; }
    }
}
