using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GameWebApi
{
    public class ErrorHandlingMiddleware
    {

        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task Invoke(HttpContext context)
        {



            try
            {


                await _next(context);



            }
            catch (NotFoundException e)
            {

                Console.WriteLine("Not Found " + e.Message);



            }

        }


    }

    public class NotFoundException : System.Exception
    {
        public NotFoundException(string message) : base(message)
        {










        }
    }


}