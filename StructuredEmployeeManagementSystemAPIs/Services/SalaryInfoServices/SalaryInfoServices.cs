using Dapper;
using System.Data.SqlClient;
using System.Data;
using StructuredEmployeeManagementSystemAPIs.Repositories.SalaryInfoRepository;
using StructuredEmployeeManagementSystemAPIs.Models;

namespace EmployManagementSystemAPIs.Services.SalaryInfoServices
{
    public class SalaryInfoServices : ISalaryInfoServices
    {
        private readonly ISalaryInfoRepository _salaryInfoRepository;
        public SalaryInfoServices(ISalaryInfoRepository salaryInfoRepository)
        {
            _salaryInfoRepository = salaryInfoRepository;
        }

        public async Task<List<SalaryInfo>> GetAllSalaryInfo()
        {
            
                var list = await _salaryInfoRepository.GetAllAsync("GetAllSalaryInfo", null);
                return list;
            
        }
        public async Task<SalaryInfo> GetSalaryInfoById(int id)
        {
            
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var salaryinfo = await _salaryInfoRepository.GetByIdAsync("GetSalaryInfoById", parameters);
                return salaryinfo;
            
        }
        public async Task<int> PostSalaryInfo(SalaryInfo salaryinfo)
        {
            
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SalaryMonth", salaryinfo.SalaryMonth);
                parameters.Add("@BasicSalary", salaryinfo.BasicSalary);
                parameters.Add("@Allowance", salaryinfo.Allowance);
                parameters.Add("@Bonus", salaryinfo.Bonus);
                parameters.Add("@TotalSalary", salaryinfo.TotalSalary);
                parameters.Add("@BasicId", salaryinfo.BasicId);
                parameters.Add("@LastInsertedId" ,dbType: DbType.Int32, direction: ParameterDirection.Output);

                await _salaryInfoRepository.Add("PostSalaryInfo", parameters);
                int LastInsertedId = parameters.Get<int>("@LastInsertedId");
            return LastInsertedId;
            
        }
        public async Task<int> UpdateSalaryInfo(SalaryInfo salaryinfo)
        {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SalaryMonth", salaryinfo.SalaryMonth);
                parameters.Add("@BasicSalary", salaryinfo.BasicSalary);
                parameters.Add("@Allowance", salaryinfo.Allowance);
                parameters.Add("@Bonus", salaryinfo.Bonus);
                parameters.Add("@TotalSalary", salaryinfo.TotalSalary);
                parameters.Add("@BasicId", salaryinfo.BasicId);
                parameters.Add("@Id", salaryinfo.Id);
                var result = await _salaryInfoRepository.Update("UpdateSalaryInfo", parameters);
                return result;
            
        }
        public async Task<int> DeleteSalaryInfo(int Id)
        {
            
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var result = await _salaryInfoRepository.Delete("DeleteSalaryInfo", parameters);
                return result;
            
        }
    }
}
