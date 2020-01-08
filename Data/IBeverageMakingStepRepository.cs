using System.Collections.Generic;
using System.Threading.Tasks;
using VendoreMachine.Domain;

namespace VendoreMachine.Data
{
    public interface IBeverageMakingStepRepository  : IRepository<BeverageMakingStep>
    {
        Task<IEnumerable<BeverageMakingStep>> GetByBeverageId(int id);
    }
}
