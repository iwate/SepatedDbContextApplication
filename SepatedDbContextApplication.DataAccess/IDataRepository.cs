using System.Collections.Generic;
using SepatedDbContextApplication.Entity;
using System.Threading.Tasks;
namespace SepatedDbContextApplication.DataAccess
{
    public interface IDataRepository
    {
        Task<Datum> Find(int id);
        IEnumerable<Datum> GetAll();
        void Add(Datum datum);
        void Remove(Datum datum);
        Task Save();
        Task<bool> IsConflict(Datum datum);
    }
}
