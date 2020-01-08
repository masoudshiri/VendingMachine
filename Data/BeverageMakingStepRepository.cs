using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendoreMachine.Common;
using VendoreMachine.Domain;

namespace VendoreMachine.Data
{
     public class BeverageMakingStepRepository : Repository<BeverageMakingStep>, IBeverageMakingStepRepository
    {
        public async Task<IEnumerable<BeverageMakingStep>> GetByBeverageId(int id)
        {
            ISampleData<BeverageMakingStep> data = UnityHelper.Retrieve<ISampleData<BeverageMakingStep>>();
            return await Task.Run( ()=> data.DbSet.Where(x => x.BeverageId == id));
        }
    }
}