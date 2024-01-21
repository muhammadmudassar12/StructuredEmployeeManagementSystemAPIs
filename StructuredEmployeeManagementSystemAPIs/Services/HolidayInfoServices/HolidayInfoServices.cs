using Dapper;
using System.Data.SqlClient;
using System.Data;
using StructuredEmployeeManagementSystemAPIs.Repositories.HolidayInfoRepository;
using StructuredEmployeeManagementSystemAPIs.Models;

namespace EmployManagementSystemAPIs.Services.HolidayInfoServices
{
    public class HolidayInfoServices : IHolidayInfoServices
    {
        private readonly IHolidayInfoRepository _holidayInfoRepository;
        public HolidayInfoServices(IHolidayInfoRepository holidayInfoRepository) 
        {
            _holidayInfoRepository=holidayInfoRepository;
        }
        public async Task<List<HolidayInfo>> GetAllHolidayInfo()
        {
            
                var list = await _holidayInfoRepository.GetAllAsync("GetAllHolidayInfo", null);
                return list;
            
        }
        public async Task<HolidayInfo> GetHolidayInfoById(int id)
        {
            
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var holidayinfo = await _holidayInfoRepository.GetByIdAsync("GetHolidayInfoById", parameters);
                return holidayinfo;
            
        }
        public async Task<int> PostHolidayInfo(HolidayInfo holidayinfo)
        {
            
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Holidays", holidayinfo.Holidays);
                parameters.Add("@Leaves", holidayinfo.Leaves);
                parameters.Add("@TotalHolidays", holidayinfo.TotalHolidays);
                parameters.Add("@BasicId", holidayinfo.BasicId);
                parameters.Add("@LastInsertedId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await _holidayInfoRepository.Add("PostHolidayInfo", parameters);
                int LastInsertedId = parameters.Get<int>("@LastInsertedId");
                return LastInsertedId;
            
        }

        public async Task<int> UpdateHolidayInfo(HolidayInfo holidayinfo)
        {            
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Holidays", holidayinfo.Holidays);
                parameters.Add("@Leaves", holidayinfo.Leaves);
                parameters.Add("@TotalHolidays", holidayinfo.TotalHolidays);
                parameters.Add("@BasicId", holidayinfo.BasicId);
                parameters.Add("@Id", holidayinfo.Id);
                var result = await _holidayInfoRepository.Update("UpdateHolidayInfo", parameters);
                return result;
            
        }
        public async Task<int> DeleteHolidayInfo(int Id)
        {       
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var result = await _holidayInfoRepository.Delete("DeleteHolidayInfo", parameters);
                return result;
            
        }
    }
}

