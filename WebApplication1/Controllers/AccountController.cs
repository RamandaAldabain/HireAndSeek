using HireAndSeek.Data;
using HireAndSeek.Entities;
using HireAndSeek.Service;
using HireAndSeek.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace HireAndSeek.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		public readonly AccountService _accountService;
		public readonly JwtAuthenticationManager _JwtAuthenticationManager;
		public readonly DatabaseContext _dbContext;
		public AccountController(AccountService accountManagerService, DatabaseContext db, JwtAuthenticationManager jwtAuthenticationManager)
		{
			_accountService = accountManagerService;
			_dbContext = db;
			_JwtAuthenticationManager = jwtAuthenticationManager;
		}

		[HttpPost]
		public IActionResult CreateOrUpdateUserAsync([FromForm] UserDto model)
		{
			if (ModelState.IsValid)
			{
				var emailExists =  _dbContext.Users.FirstOrDefault(e => e.Email == model.Email);

				if (emailExists != null)
				{
					throw new Exception("Email Already Exists");
				}

				if (model.Password != model.ConfirmPassword)
				{
					throw new Exception("Passwords do not match");
				}

				var user =  _accountService.CreateOrUpdateUser(model);

				return Ok(new { message = "Operation successful", data = user });
			}
			else
			{
				return BadRequest(new { error = "Invalid model data" });
			}
		}


		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
		{
			var token = await _JwtAuthenticationManager.AuthenticateAsync(loginRequest.Email, loginRequest.Password);

			if (token == null)
			{
				return Unauthorized();
			}

			return Ok(new AuthResponse
			{
				Token = token,
				Result = true
			});
		}

	}
}
