namespace SenseWebApi1.Context
{
    public interface IPersonContext
    {
       public bool IsAuthorized(string login, string password);
    }
}
