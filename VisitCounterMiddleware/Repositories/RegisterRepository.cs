namespace VisitCounterMiddleware.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private int registerCount = 0;
        
        public int RegisterVisit()
        {
            return Interlocked.Increment(ref registerCount);
        }
    }
}
