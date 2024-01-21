using StructuredEmployeeManagementSystemAPIs.Connection;
using StructuredEmployeeManagementSystemAPIs.Models;
using StructuredEmployeeManagementSystemAPIs.Repositories.BaseEntityRepository;
using System;

namespace StructuredEmployeeManagementSystemAPIs.Repositories.BasicInfoRepository
{
    public class BasicInfoRepository : EntityRepository<BasicInfo>, IBasicInfoRepository
    {
        public BasicInfoRepository(IConnectionString context) : base(context)
        {

        }
    }
}
