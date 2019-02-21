using ATM.Core.Data;

namespace ATM.Services
{
    abstract class BaseServiceClass
    {
        public IUnitOfWork UnitOfWork { get; }
        protected BaseServiceClass(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
