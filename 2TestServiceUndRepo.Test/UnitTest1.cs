using _2TestServiceUndRepo.Repositories;

namespace _2TestServiceUndRepo.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            UserRepository repo = new UserRepository();
            repo.CreateUser(new Models.User {Name = "Alice" });
        }
    }
}
