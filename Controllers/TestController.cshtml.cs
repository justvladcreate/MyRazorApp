using Microsoft.AspNetCore.Mvc;
using System;

namespace MyRazorApp.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet("GetRandom")]
        public ActionResult GetRandom()
        {
            var random = new Random();
            var number = random.Next(1, 11);
            return Ok(number);
        }
        [HttpGet("GetText")]
        public ActionResult GetText()
        {
            var hello = "hello";
            var world = "world!";
            var result = hello + " " + world;
            return Ok(result);
        }

        [HttpGet("GetMultiply/{number}")]
        public ActionResult GetMultiply(int number)
        {
            var result = number * 2;

            return Ok(result);
        }
    }
}