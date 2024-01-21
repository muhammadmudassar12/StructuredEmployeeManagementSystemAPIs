using CoreWebapi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using StructuredEmployeeManagementSystemAPIs.Models;

namespace StructuredEmployeeManagementSystemAPIs.Controllers
{
    [ApiController]
    [ApplicationExceptionFilter]
    public class BaseApiController : Controller
    {
        protected IActionResult Success(dynamic data = null)
        {
            var responseValue = BuildSuccessResponse(data);
            return Ok(responseValue);
        }
        protected IActionResult CreatedWithId(string id)
        {
            //var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            //var uri = showUri ? $"{baseUrl}/{baseApi}/{segment}" : "";
            //var responseValue = BuildSuccessResponse(new { id = id });
            return Success(new { id = id });
            //return Created(uri, responseValue);
        }
        protected IActionResult CreatedWithIds(List<string> ids, string segment, string baseApi = "api", bool showUri = true)
        {
            //var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            //var uri = showUri ? $"{baseUrl}/{baseApi}/{segment}" : "";
            //var responseValue = BuildSuccessResponse(new { id = id });

            List<dynamic> json = new List<dynamic>();
            foreach (var value in ids)
            {
                json.Add(new { id = value });
            }
            return Success(json);
        }

        private JsonResponse BuildSuccessResponse(dynamic data)
        {
            JsonResponse model = new JsonResponse();
            model.success = true;
            model.data = data;
            MetaData objmetadata = new MetaData();
            model.metadata = objmetadata;
            return model;
        }
    }
}
