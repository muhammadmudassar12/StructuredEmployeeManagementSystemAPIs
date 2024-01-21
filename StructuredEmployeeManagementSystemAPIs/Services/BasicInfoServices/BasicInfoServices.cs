using Dapper;
using System.Data;
using System.Data.SqlClient;
using StructuredEmployeeManagementSystemAPIs.Models;
using StructuredEmployeeManagementSystemAPIs.Repositories.BasicInfoRepository;


namespace EmployManagementSystemAPIs.Services.BasicInfoServices
{
    public class BasicInfoServices : IBasicInfoServices
    {
        private readonly IBasicInfoRepository _basicInfoRepository;
        public BasicInfoServices(IBasicInfoRepository basicInfoRepository)
        {
            _basicInfoRepository = basicInfoRepository;
        }

        public async Task<List<BasicInfo>> GetAllBasicInfo()
        {
           
                var list = await _basicInfoRepository.GetAllAsync("GetAllBasicInfo", null);
                return list;
            
        }
        public async Task<BasicInfo> GetBasicInfoById(int id)
        {          
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
            var basicinfo = await _basicInfoRepository.GetByIdAsync("GetBasicInfoById", parameters);
                return basicinfo;
            
        }
        public async Task<int> PostBasicInfo(BasicInfo basicinfo)
        {
            
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", basicinfo.Name);
                parameters.Add("@Email", basicinfo.Email);
                parameters.Add("@Address", basicinfo.Address);
                parameters.Add("@Gender", basicinfo.Gender);
                parameters.Add("@Position", basicinfo.Position);
                parameters.Add("@LastInsertedId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await _basicInfoRepository.Add("PostBasicInfo", parameters);
                int LastInsertedId = parameters.Get<int>("@LastInsertedId");
                return LastInsertedId;
            
        }
        public async Task<int> UpdateBasicInfo(BasicInfo basicinfo)
        {
           
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", basicinfo.Name);
                parameters.Add("@Email", basicinfo.Email);
                parameters.Add("@Address", basicinfo.Address);
                parameters.Add("@Gender", basicinfo.Gender);
                parameters.Add("@Position", basicinfo.Position);
                parameters.Add("@Id", basicinfo.Id);

                var result = await _basicInfoRepository.Update("UpdateBasicInfo", parameters);
                return result;
            
        }
        public async Task<int> DeleteBasicInfo(int Id)
        {
          
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var result = await _basicInfoRepository.Delete("DeleteBasicInfo", parameters);
                return result;
            
        }
    }
}
