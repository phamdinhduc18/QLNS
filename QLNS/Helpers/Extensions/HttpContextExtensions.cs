using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QLNS.Helpers.Extensions
{
    public static class HttpContextExtensions
    {
        public static int? GetId(this HttpRequest Request)
        {
            var claimId = Request.HttpContext.User.FindFirst(ClaimTypes.Name);
            if (claimId == null) return null;
            int.TryParse(claimId.Value, out int result);
            return result;
        }
    }
}
