namespace DataAccess.Models.Base
{
    public class InfrastructureBase
    {
        public string Name { get; set; }

        public int MaxStudents { get; set; }

        public virtual int StateId { get; set; }

        public string ConfigurationFolder { get; set; }

        public int TypeInfrastructureId { get; set; }
    }
}
