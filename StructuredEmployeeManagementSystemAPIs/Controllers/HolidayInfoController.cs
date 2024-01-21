using CoreWebapi.Exceptions;
using EmployManagementSystemAPIs.Services.HolidayInfoServices;
using Microsoft.AspNetCore.Mvc;
using StructuredEmployeeManagementSystemAPIs.Models;

namespace StructuredEmployeeManagementSystemAPIs.Controllers
{
    public class HolidayInfoController : BaseApiController
    {
        private readonly IHolidayInfoServices _holidayinfoservices;
        public HolidayInfoController(IHolidayInfoServices holidayinfoservices)
        {
            _holidayinfoservices = holidayinfoservices;
        }

        [HttpGet("api/HolidayInfo")]
        public async Task<IActionResult> GetAllHolidayInfo()
        {
            var holidayinfo = await _holidayinfoservices.GetAllHolidayInfo();
            if (holidayinfo.Count == 0)
            {
                throw new EntityNotFoundException();
            }
            return Success(holidayinfo);
        }
        [HttpGet("api/HolidayInfo/{id}")]
        public async Task<IActionResult> GetHolidayInfoById(int id)
        {
            var holidayinfo = await _holidayinfoservices.GetHolidayInfoById(id);
            if (holidayinfo == null)
            {
                throw new EntityNotFoundException($"{id} not found in database.");
            }
            return Success(holidayinfo);
        }
        [HttpPost("api/HolidayInfo")]
        public async Task<IActionResult> CreateHolidayInfo([FromBody] HolidayInfo holidayinfo)
        {
            try
            {
                if (holidayinfo == null)
                    throw new ArgumentNullException(nameof(holidayinfo));
                int lastInsertedId = await _holidayinfoservices.PostHolidayInfo(holidayinfo);
                return CreatedWithId(Convert.ToString(lastInsertedId));

            }
            catch (Exception e)
            {
                throw new InternalServerException(e.ToString());
            }

        }
        [HttpPut("api/HolidayInfo/{id}")]
        public async Task<IActionResult> UpdateHolidayInfo(int id, [FromBody] HolidayInfo holidayinfo)
        {
            try
            {
                var dbHolidayInfo = await _holidayinfoservices.GetHolidayInfoById(id);
                if (dbHolidayInfo == null)
                {
                    throw new EntityNotFoundException($"HolidayInfo Id {id} not found..");
                }
                // employee.Id=dbEmployee.Id;
                holidayinfo.Id = id;
                int result = await _holidayinfoservices.UpdateHolidayInfo(holidayinfo);
                var updatedHolidayInfo = await _holidayinfoservices.GetHolidayInfoById(id);
                return Success(updatedHolidayInfo);
                //else
                //    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                throw new InternalServerException(e.Message);
            }

        }
        [HttpDelete("api/HolidayInfo/{id}")]
        public async Task<IActionResult> DeleteHolidayInfo(int id)
        {
            try
            {
                var dbHolidayInfoHolidayInfo = await _holidayinfoservices.GetHolidayInfoById(id);
                if (dbHolidayInfoHolidayInfo == null)
                {
                    throw new EntityNotFoundException($"HolidayInfo Id {id} not found..");
                }
                int result = await _holidayinfoservices.DeleteHolidayInfo(id);
                return Success();
                //else
                //    return this.BadRequest("false");

            }
            catch (Exception e)
            {
                throw new InternalServerException(e.Message);
            }

        }
    }
}
