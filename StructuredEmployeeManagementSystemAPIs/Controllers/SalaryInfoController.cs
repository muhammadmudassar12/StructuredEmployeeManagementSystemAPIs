using CoreWebapi.Exceptions;
using EmployManagementSystemAPIs.Services.EmgContactInfoServices;
using EmployManagementSystemAPIs.Services.SalaryInfoServices;
using Microsoft.AspNetCore.Mvc;
using StructuredEmployeeManagementSystemAPIs.Models;

namespace StructuredEmployeeManagementSystemAPIs.Controllers
{
    public class SalaryInfoController : BaseApiController
    {
        private readonly ISalaryInfoServices _salaryInfoServices;
        public SalaryInfoController(ISalaryInfoServices salaryInfoServices)
        {
            _salaryInfoServices = salaryInfoServices;
        }
        [HttpGet("api/SalaryInfo")]
        public async Task<IActionResult> GetAllSalaryInfo()
        {
            var salaryInfo = await _salaryInfoServices.GetAllSalaryInfo();
            if (salaryInfo.Count == 0)
            {
                throw new EntityNotFoundException();
            }
            return Success(salaryInfo);
        }
        [HttpGet("api/SalaryInfo/{id}")]
        public async Task<IActionResult> GetSalaryInfoById(int id)
        {
            var salaryInfo = await _salaryInfoServices.GetSalaryInfoById(id);
            if (salaryInfo == null)
            {
                throw new EntityNotFoundException($"{id} not found in database.");
            }
            return Success(salaryInfo);
        }
        [HttpPost("api/SalaryInfo")]
        public async Task<IActionResult> PostSalaryInfo([FromBody] SalaryInfo salaryInfo)
        {
            try
            {
                if (salaryInfo == null)
                    throw new ArgumentNullException(nameof(salaryInfo));
                int lastInsertedId = await _salaryInfoServices.PostSalaryInfo(salaryInfo);
                return CreatedWithId(Convert.ToString(lastInsertedId));

            }
            catch (Exception e)
            {
                throw new InternalServerException(e.ToString());
            }

        }
        [HttpPut("api/SalaryInfo/{id}")]
        public async Task<IActionResult> UpdateSalaryInfo(int id, [FromBody] SalaryInfo salaryInfo)
        {
            try
            {
                var dbSalaryInfo = await _salaryInfoServices.GetSalaryInfoById(id);
                if (dbSalaryInfo == null)
                {
                    throw new EntityNotFoundException($"SalaryInfo Id {id} not found..");
                }
             
                salaryInfo.Id = id;
                int result = await _salaryInfoServices.UpdateSalaryInfo(salaryInfo);
                var updatedSalaryInfo = await _salaryInfoServices.GetSalaryInfoById(id);
                return Success(updatedSalaryInfo);
                //else
                //    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                throw new InternalServerException(e.Message);
            }

        }
        [HttpDelete("api/SalaryInfo/{id}")]
        public async Task<IActionResult> DeleteSalaryInfo(int id)
        {
            try
            {
                var dbSalaryInfo = await _salaryInfoServices.GetSalaryInfoById(id);
                if (dbSalaryInfo == null)
                {
                    throw new EntityNotFoundException($"SalaryInfo Id {id} not found..");
                }
                int result = await _salaryInfoServices.DeleteSalaryInfo(id);
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
