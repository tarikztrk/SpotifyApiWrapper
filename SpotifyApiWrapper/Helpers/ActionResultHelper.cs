using Microsoft.AspNetCore.Mvc;
using SpotifyApiWrapper.Entities;
using System.Net;

namespace SpotifyApiWrapper.Helpers
{
    public static class ActionResultHelper
    {
        public static IActionResult HandleActionResult(this ControllerBase controllerBase, HttpStatusCode statusCode, object obj, string? faultDescription = null)
        {

            if (statusCode.IsSuccessStatusCode())
            {
                if (statusCode == HttpStatusCode.Created)
                {
                    return controllerBase.Created("", obj);
                }
                else if (statusCode == HttpStatusCode.OK)
                {
                    return controllerBase.Ok(obj);
                }
            }
            else
            {
                var errorDetail = new HttpErrorResponse
                {

                    Detail = faultDescription,
                    Message = faultDescription
                };

                controllerBase.Response.Headers.Add("X-Fault-Description", faultDescription);

                if (statusCode == HttpStatusCode.BadRequest)
                {
                    return controllerBase.BadRequest(errorDetail);
                }
                else if ((int)statusCode == 422)
                {
                    return controllerBase.UnprocessableEntity(errorDetail);
                }
                else if (statusCode == HttpStatusCode.Conflict)
                {
                    return controllerBase.Conflict(errorDetail);
                }
                else if (statusCode == HttpStatusCode.Unauthorized)
                {
                    return controllerBase.StatusCode(401, errorDetail);
                }
                else if (statusCode == HttpStatusCode.NotFound)
                {
                    return controllerBase.NotFound(errorDetail);
                }
                else if (statusCode == HttpStatusCode.InternalServerError)
                {
                    return controllerBase.StatusCode(500, errorDetail);
                }
            }

            return new StatusCodeResult((int)statusCode);
        }
    }
    public static class HttpStatusCodeExt
    {
        public static bool IsSuccessStatusCode(this HttpStatusCode statusCode)
        {
            var asInt = (int)statusCode;
            return asInt >= 200 && asInt <= 299;
        }
    }
}
