namespace DataAccess.Models.Base
{
    public class ClientBase
    {
        public virtual string Name { get; set; }

        public virtual string Abbreviation { get; set; }

        public int AmountStudents { get; set; }

        public virtual int StateId { get; set; }
    }
}
