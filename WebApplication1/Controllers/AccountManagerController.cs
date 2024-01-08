using HireAndSeek.Data;
using HireAndSeek.Entities;
using HireAndSeek.Service;
using HireAndSeekEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AccountManagerController : ControllerBase
	{
		public readonly AccountManagerService _AccountManagerService;
		public readonly JwtAuthenticationManager _JwtAuthenticationManager;
		public readonly DatabaseContext _db;
		public AccountManagerController(AccountManagerService accountManagerService, DatabaseContext db, JwtAuthenticationManager jwtAuthenticationManager)
		{
			_AccountManagerService = accountManagerService;
			_db = db;
			_JwtAuthenticationManager = jwtAuthenticationManager;
		}

		[HttpPost]
		public IActionResult CreateOrUpdateUser([FromForm] UserDto model)
		{
			if(ModelState.IsValid)
			{
				var email = _db.Users.Any(e=>e.Email == model.Email);
				if(email) throw new Exception("Email Already Exist"); 
				if (model.Password != model.ConfirmPassword)
					throw new Exception("Passwords does not match");
			var user =_AccountManagerService.CreateOrUpdateUser(model);
				return Ok(new { message = "Operation successful", data = user });
			}
			else
			{
				return BadRequest(new { error = "Invalid model data" });
			}
		}

		[HttpPost]
		public IActionResult Login([FromBody] LoginRequest loginRequest)
		{
			var token = _JwtAuthenticationManager.Authenticate(loginRequest.Email, loginRequest.Password);
			if (token == null) Unauthorized();
			return Ok(new AuthResponse
			{
				Token = token,
				Result= true
			}
			);
		}

	}
}
