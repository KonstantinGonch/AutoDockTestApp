using AutoDockTestApp.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDockTestApp.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected BaseApiResponse<T> CreateSuccessResponse<T>(T data)
        {
            return new BaseApiResponse<T>
            {
                Success = true,
                ErrorMessage = string.Empty,
                Response = data
            };
        }
    }
}
