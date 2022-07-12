namespace API.Models.Client
{
    using DataAccess.Models.Base;

    public class ClientPost
    {
        public virtual string Name { get; set; }

        public virtual string Abbreviation { get; set; }

        public int AmountStudents { get; set; }

        public NameModel State { get; set; }

        public virtual ICollection<NameModel>? Products { get; set; }

        public virtual ICollection<NameModel> Infrastructures { get; set; }
    }
}
