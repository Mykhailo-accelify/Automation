namespace DataAccess.Models.Interfaces.Primitives;

public interface IClientColumns : INamed, IAbbreviated
{
    public int AmountStudents { get; set; }

}