using _2TestServiceUndRepo.Controllers;
using _2TestServiceUndRepo.Repositories;
using _2TestServiceUndRepo.Services;
using Microsoft.AspNetCore.Mvc;

namespace _2TestServiceUndRepo.Ttest
{
    public class UnitTest1
    {
        [Fact]
        public void ControllerCreatesUser()
        {
            UsersController controller = new UsersController(new Service(new UserRepository()));

            var result = controller.Create("Alice", 30);

            Assert.IsType<ViewResult>(result);
        }
    }
}
