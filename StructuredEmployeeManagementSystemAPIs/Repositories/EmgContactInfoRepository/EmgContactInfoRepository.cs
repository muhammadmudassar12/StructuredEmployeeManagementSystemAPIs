using StructuredEmployeeManagementSystemAPIs.Connection;
using StructuredEmployeeManagementSystemAPIs.Models;
using StructuredEmployeeManagementSystemAPIs.Repositories.BaseEntityRepository;

namespace StructuredEmployeeManagementSystemAPIs.Repositories.EmgContactInfoRepository
{
    public class EmgContactInfoRepository : EntityRepository<EmgContactInfo>, IEmgContactInfoRepository
    {
        public EmgContactInfoRepository(IConnectionString context) : base(context)
        {

        }
    }
}
