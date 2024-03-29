﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace OnlineShop.UI.Core.Extensions
{
    public static class HttpContextExtensions
    {
        public static async Task WriteError(this HttpContext httpContext, object error)
        {
            httpContext.Response.StatusCode = 500;
            httpContext.Response.Headers.Add("Content-Type", "application/json");
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }

        public static async Task WriteError(this HttpContext httpContext, object error, int statusCode)
        {
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.Headers.Add("Content-Type", "application/json");
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
        }

        public static async Task WriteJsonAsync(this HttpContext httpContext, object obj)
        {
            httpContext.Response.StatusCode = 200;
            httpContext.Response.Headers.Add("Content-Type", "application/json");
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(obj));
        }

        public static bool IsGet(this HttpRequest request) => request.Method == "Get" ? true : false;


        public static bool IsPost(this HttpRequest request) => request.Method == "Post" ? true : false;


        public static bool IsPut(this HttpRequest request) => request.Method == "Put" ? true : false;


        public static bool IsPatch(this HttpRequest request)
        {
            if (request.Method == "PATCH")
                return true;
            return false;
        }

        public static bool IsDelete(this HttpRequest request)
        {
            if (request.Method == "DELETE")
                return true;
            return false;
        }

        public static bool IsOptions(this HttpRequest request)
        {
            if (request.Method == "OPTIONS")
                return true;
            return false;
        }

        public static bool IsHead(this HttpRequest request)
        {
            if (request.Method == "HEAD")
                return true;
            return false;
        }

        public static bool HasFileCount(this HttpContext context)
        {
            var result = !string.IsNullOrEmpty(context.Request.Headers["X-MultiSelect"]);
            return result;
        }

        public static string GetFilesCount(this HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Headers["X-MultiSelect"]))
            {
                return context.Request.Headers["X-MultiSelect"];
            }

            return string.Empty;
        }

        public static bool HasAuthorization(this HttpContext context)
        {
            var result = !string.IsNullOrEmpty(context.Request.Headers["Authorization"]);
            return result;
        }

        public static string GetAuthorizationToken(this HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Headers["Authorization"])) return string.Empty;

            const string authenticationSchema = "Bearer";
            var userToken = context.Request.Headers["Authorization"].ToString();
            return userToken.Replace($"{authenticationSchema} ", "");
        }

        public static bool HasLanguage(this HttpContext httpContext)
        {
            var language = httpContext.Request.Headers["Accept-Language"];
            if (string.IsNullOrWhiteSpace(language))
            {
                return false;
            }

            return true;
        }

        public static string GetLanguage(this HttpRequest request)
        {
            var language = request.Headers["Accept-Language"];
            return language;
        }

        public static void SetLanguage(this HttpResponse response, string language)
        {
            response.Headers["Accept-Language"] = language;
        }
    }
}