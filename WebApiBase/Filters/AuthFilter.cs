using System;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiBase.Enums;
using WebApiBase.Extensions;
using WebApiBase.Models;

namespace WebApiBase.Filters
{
    public class AuthFilter<T> : IActionFilter where T : class
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var requestModel = context.ActionArguments["request"] as RequestModel<T>;
            if (requestModel == null)
            {
                context.Result = new ResponseModel<object>
                {
                    Success = false,
                    Code = BaseCode.AuthFilter.AuthError001.ToString(),
                    Message = BaseCode.AuthFilter.AuthError001.GetDescription()
                };
                return;
            }

            if (string.IsNullOrEmpty(requestModel.ApiKey) ||
                string.IsNullOrEmpty(requestModel.Signature))
                context.Result = new ResponseModel<object>
                {
                    Success = false,
                    Code = BaseCode.AuthFilter.AuthError002.ToString(),
                    Message = BaseCode.AuthFilter.AuthError002.GetDescription()
                };

            // todo get auth from database by ApiKey.(use Redis as cache)
            // context.Result = new ResponseModel<object>
            // {
            //     Success = false,
            //     Code = BaseCode.AuthFilter.AuthError003.ToString(),
            //     Message = BaseCode.AuthFilter.AuthError003.GetDescription()
            // };

            // todo use public key cryptography to check signature
            // context.Result = new ResponseModel<object>
            // {
            //     Success = false,
            //     Code = BaseCode.AuthFilter.AuthError004.ToString(),
            //     Message = BaseCode.AuthFilter.AuthError004.GetDescription()
            // };
        }
    }
}