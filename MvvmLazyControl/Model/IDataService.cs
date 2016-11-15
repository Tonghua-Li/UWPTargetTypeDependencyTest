using System.Threading.Tasks;

namespace MvvmLazyControl.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}