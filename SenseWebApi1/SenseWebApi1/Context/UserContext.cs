using SenseWebApi1.domain.Entities;

namespace SenseWebApi1.Context
{
    public class UserContext
    {
        List<User> Users = new List<User>();

        public UserContext() 
        {
            Users.Add(
                new User()
                {
                    UserId= Guid.Parse("d04a76aa-2f20-4af9-a39e-427623323374"),
                    UserName="User 1"
                });
            Users.Add(
                new User()
                {
                    UserId = Guid.Parse("da2a7240-8fbb-48eb-bdcb-cc154593587f"),
                    UserName = "User 1"
                });
        }

    }
}
