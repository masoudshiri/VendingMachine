using System.Collections.Generic;
using System.Threading.Tasks;
using VendoreMachine.Domain;
namespace VendoreMachine.Data
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();

    }
}
