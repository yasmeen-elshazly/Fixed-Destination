using Microsoft.AspNetCore.Mvc;
using My_Uber.DTOs;
using My_Uber.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using My_Uber.Context.Context;
using Models;
using System.Security.Claims;
using My_Uber.Services;


namespace My_Uber.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                // Log claims
                foreach (var claim in claims)
                {
                    Console.WriteLine($"Claim: {claim.Type} Value: {claim.Value}");
                }
            }

            var query = _userService.GetAll();
            return Ok(query);
        }
    }
}
