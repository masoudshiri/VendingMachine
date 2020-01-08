using System.Collections.Generic;
using VendoreMachine.Domain;

namespace VendoreMachine.Data
{
    public interface ISampleData<T> where T : EntityBase
    {
       IEnumerable<T> DbSet { get;  }
    }
}
