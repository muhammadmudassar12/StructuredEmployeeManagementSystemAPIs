using StructuredEmployeeManagementSystemAPIs.Connection;
using StructuredEmployeeManagementSystemAPIs.Models;
using StructuredEmployeeManagementSystemAPIs.Repositories.BaseEntityRepository;

namespace StructuredEmployeeManagementSystemAPIs.Repositories.HolidayInfoRepository
{
    public class HolidayInfoRepository :EntityRepository<HolidayInfo>, IHolidayInfoRepository
    {
        public HolidayInfoRepository(IConnectionString context) : base(context) 
        {
        }
    }
}
