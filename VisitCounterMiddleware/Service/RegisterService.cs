using VisitCounterMiddleware.Repositories;

namespace VisitCounterMiddleware.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly RegisterRepository _repository;

        public RegisterService(RegisterRepository repos)
        {
            _repository = repos;
        }

        public int RegisterVisit()
        {
            return _repository.RegisterVisit();
        }
    }
}
