using Dapper;
using System.Data.SqlClient;
using System.Data;
using StructuredEmployeeManagementSystemAPIs.Models;
using StructuredEmployeeManagementSystemAPIs.Repositories.EmgContactInfoRepository;


namespace EmployManagementSystemAPIs.Services.EmgContactInfoServices
{
    public class EmgContactInfoServices : IEmgContactInfoServices
    {
        private readonly IEmgContactInfoRepository _emgcontactinforepository;
        public EmgContactInfoServices(IEmgContactInfoRepository emgcontactinforepository)
        {
            _emgcontactinforepository = emgcontactinforepository;
        }
        public async Task<List<EmgContactInfo>> GetAllEmgContactInfo()
        {         
                var list = await _emgcontactinforepository.GetAllAsync("GetAllEmgContactInfo", null);
                return list;
            
        }
        public async Task<EmgContactInfo> GetEmgContactInfoById(int id)
        {
           
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var emgcontactinfo = await _emgcontactinforepository.GetByIdAsync("GetEmgContactInfoById", parameters);
                return emgcontactinfo;
            
        }
        public async Task<int> PostEmgContactInfo(EmgContactInfo emgcontactinfo)
        {
            
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmgContactName", emgcontactinfo.EmgContactName);
                parameters.Add("@EmgContactPhone", emgcontactinfo.EmgContactPhone);
                parameters.Add("@EmgContactEmail", emgcontactinfo.EmgContactEmail);
                parameters.Add("@BasicId", emgcontactinfo.BasicId);
                parameters.Add("@LastInsertedId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await _emgcontactinforepository.Add("PostEmgContactInfo", parameters);
                int LastInsertedId = parameters.Get<int>("@LastInsertedId");
                return LastInsertedId;
           
        }
        public async Task<int> UpdateEmgContactInfo(EmgContactInfo emgcontactinfo)
        {
           
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmgContactName", emgcontactinfo.EmgContactName);
                parameters.Add("@EmgContactPhone", emgcontactinfo.EmgContactPhone);
                parameters.Add("@EmgContactEmail", emgcontactinfo.EmgContactEmail);
                parameters.Add("@BasicId", emgcontactinfo.BasicId);
                parameters.Add("@Id", emgcontactinfo.Id);

                var result = await _emgcontactinforepository.Update("UpdateEmgContactInfo", parameters);
                return result;
            
        }
        public async Task<int> DeleteEmgContactInfo(int Id)
        {
         
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var result = await _emgcontactinforepository.Delete("DeleteEmgContactInfo", parameters);
                return result;
            
        }
    }
}

