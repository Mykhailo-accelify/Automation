using API.Interfaces.Models.Create;
using DataAccess.Models.Interfaces.Primitives;

namespace API.Models.Update
{
    public class UpdateClient : ICreateClient, IIdentified
    {
        public int Id { get; set; }
        public int AmountStudents { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public INamed State { get; set; }
        public ICollection<INamed>? Products { get; set; }
        public ICollection<INamed> Infrastructures { get; set; }
    }
}
