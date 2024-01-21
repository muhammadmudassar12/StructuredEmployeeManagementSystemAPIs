using CoreWebapi.Exceptions;
using EmployManagementSystemAPIs.Services.BasicInfoServices;
using EmployManagementSystemAPIs.Services.EmgContactInfoServices;
using Microsoft.AspNetCore.Mvc;
using StructuredEmployeeManagementSystemAPIs.Models;

namespace StructuredEmployeeManagementSystemAPIs.Controllers
{
    public class EmgContactInfoController : BaseApiController
    {
        private readonly IEmgContactInfoServices _emgContactInfoServices;
        public EmgContactInfoController(IEmgContactInfoServices emgContactInfoServices)
        {
            _emgContactInfoServices = emgContactInfoServices;
        }
        [HttpGet("api/EmgContactInfo")] 
        public async Task<IActionResult> GetAllEmgContactInfo()
        {
            var emgcontactinfo = await _emgContactInfoServices.GetAllEmgContactInfo();
            if (emgcontactinfo.Count == 0)
            {
                throw new EntityNotFoundException();
            }
            return Success(emgcontactinfo);
        }
        [HttpGet("api/EmgContactInfo/{id}")]
        public async Task<IActionResult> GetEmgContactInfoById(int id)
        {
            var emgcontactinfo = await _emgContactInfoServices.GetEmgContactInfoById(id);
            if (emgcontactinfo == null)
            {
                throw new EntityNotFoundException($"{id} not found in database.");
            }
            return Success(emgcontactinfo);
        }
        [HttpPost("api/EmgContactInfo")]
        public async Task<IActionResult> PostEmgContactInfo([FromBody] EmgContactInfo emgcontactinfo)
        {
            try
            {
                if (emgcontactinfo == null)
                    throw new ArgumentNullException(nameof(emgcontactinfo));
                int lastInsertedId = await _emgContactInfoServices.PostEmgContactInfo(emgcontactinfo);
                return CreatedWithId(Convert.ToString(lastInsertedId));

            }
            catch (Exception e)
            {
                throw new InternalServerException(e.ToString());
            }

        }
        [HttpPut("api/EmgContactInfo/{id}")]
        public async Task<IActionResult> UpdateEmgContactInfo(int id, [FromBody] EmgContactInfo emgcontactinfo)
        {
            try
            {
                var dbEmgContactInfo = await _emgContactInfoServices.GetEmgContactInfoById(id);
                if (dbEmgContactInfo == null)
                {
                    throw new EntityNotFoundException($"EmgContactInfo Id {id} not found..");
                }
                // employee.Id=dbEmgContact.Id;
                emgcontactinfo.Id = id;
                int result = await _emgContactInfoServices.UpdateEmgContactInfo(emgcontactinfo);
                var updatedEmgContactInfo = await _emgContactInfoServices.GetEmgContactInfoById(id);
                return Success(updatedEmgContactInfo);
                //else
                //    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                throw new InternalServerException(e.Message);
            }

        }
        [HttpDelete("api/EmgContactInfo/{id}")]
        public async Task<IActionResult> DeleteEmgContactInfo(int id)
        {
            try
            {
                var dbEmgContactInfo = await _emgContactInfoServices.GetEmgContactInfoById(id);
                if (dbEmgContactInfo == null)
                {
                    throw new EntityNotFoundException($"EmgContactInfo Id {id} not found..");
                }
                int result = await _emgContactInfoServices.DeleteEmgContactInfo(id);
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
