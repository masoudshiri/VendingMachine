using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendoreMachine.Common;
using VendoreMachine.Domain;
namespace VendoreMachine.Data
{
     public class Repository<T> : IRepository<T> where T : EntityBase
    {
        public async Task<T> GetById(int id)
        {
            ISampleData<T> data = UnityHelper.Retrieve<ISampleData<T>>();
            return await Task.Run( ()=> data.DbSet.First(x => x.Id == id));
        }
          
        public async Task<IEnumerable<T>> GetAll()
        {
                ISampleData<T> data = UnityHelper.Retrieve<ISampleData<T>>();
                return await Task.Run(() => data.DbSet.AsEnumerable());
        }
    }
}