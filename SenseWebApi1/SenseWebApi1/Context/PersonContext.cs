namespace SenseWebApi1.Context
{
    public class PersonContext:IPersonContext
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public bool IsAuthorized(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
