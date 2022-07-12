namespace API.Athentication
{
    using System.Security.Principal;

    public class APIUser : IIdentity
    {
        public APIUser(string? authenticationType, bool isAuthenticated, string? name)
        {
            AuthenticationType = authenticationType;
            IsAuthenticated = isAuthenticated;
            Name = name;
        }

        public string? AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string? Name { get; set; }
    }
}
