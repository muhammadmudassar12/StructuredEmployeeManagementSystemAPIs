using CoreWebapi.Exceptions;
using EmployManagementSystemAPIs.Services.BasicInfoServices;
using Microsoft.AspNetCore.Mvc;
using StructuredEmployeeManagementSystemAPIs.Models;

namespace StructuredEmployeeManagementSystemAPIs.Controllers
{
    public class BasicInfoController : BaseApiController
    {
        private readonly IBasicInfoServices _basicInfoServices;
        public BasicInfoController(IBasicInfoServices basicInfoServices)
        {
            _basicInfoServices = basicInfoServices;
        }
        [HttpGet("api/BasicInfo")]
        public async Task<IActionResult> GetAllBasicInfo()
        {
            var basicinfo = await _basicInfoServices.GetAllBasicInfo();
            if (basicinfo.Count == 0)
            {
                throw new EntityNotFoundException();
            }
            return Success(basicinfo);
        }
        [HttpGet("api/BasicInfo/{id}")]
        public async Task<IActionResult> GetBasicInfoById(int id)
        {
            var basicinfo = await _basicInfoServices.GetBasicInfoById(id);
            if (basicinfo == null)
            {
                throw new EntityNotFoundException($"{id} not found in database.");
            }
            return Success(basicinfo);
        }
        [HttpPost("api/BasicInfo")]
        public async Task<IActionResult> PostBasicInfo([FromBody] BasicInfo basicinfo)
        {
            try
            {
                if (basicinfo == null)
                    throw new ArgumentNullException(nameof(basicinfo));
                int lastInsertedId = await _basicInfoServices.PostBasicInfo(basicinfo);
                return CreatedWithId(Convert.ToString(lastInsertedId));

            }
            catch (Exception e)
            {
                throw new InternalServerException(e.ToString());
            }

        }
        [HttpPut("api/BasicInfo/{id}")]
        public async Task<IActionResult> UpdateBasicInfo(int id, [FromBody] BasicInfo basicInfo)
        {
            try
            {
                var dbBasicInfo = await _basicInfoServices.GetBasicInfoById(id);
                if (dbBasicInfo == null)
                {
                    throw new EntityNotFoundException($"BasicInfo Id {id} not found..");
                }
                // employee.Id=dbEmployee.Id;
                basicInfo.Id = id;
                int result = await _basicInfoServices.UpdateBasicInfo(basicInfo);
                var updatedBasicInfo = await _basicInfoServices.GetBasicInfoById(id);
                return Success(updatedBasicInfo);
                //else
                //    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                throw new InternalServerException(e.Message);
            }

        }
        [HttpDelete("api/BasicInfo/{id}")]
        public async Task<IActionResult> DeleteBasicInfo(int id)
        {
            try
            {
                var dbBasicInfo = await _basicInfoServices.GetBasicInfoById(id);
                if (dbBasicInfo == null)
                {
                    throw new EntityNotFoundException($"BasicInfo Id {id} not found..");
                }
                int result = await _basicInfoServices.DeleteBasicInfo(id);
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
