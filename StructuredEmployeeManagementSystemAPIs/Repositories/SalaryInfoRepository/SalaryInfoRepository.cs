using StructuredEmployeeManagementSystemAPIs.Connection;
using StructuredEmployeeManagementSystemAPIs.Models;
using StructuredEmployeeManagementSystemAPIs.Repositories.BaseEntityRepository;

namespace StructuredEmployeeManagementSystemAPIs.Repositories.SalaryInfoRepository
{
    public class SalaryInfoRepository : EntityRepository<SalaryInfo>, ISalaryInfoRepository
    {
        public SalaryInfoRepository(IConnectionString context) : base(context)
        {

        }
    }
}
