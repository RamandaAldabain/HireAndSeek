using HireAndSeek.Data;
using HireAndSeek.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Service
{
	public class JwtAuthenticationManager
	{
		private readonly string _key;
		private readonly AccountService _accountManagerService;




		public JwtAuthenticationManager(string key, AccountService accountManagerService)
		{
			_key = key;
			_accountManagerService = accountManagerService;
		}

		public async Task<string> AuthenticateAsync(string email, string password)
		{
			if (!await _accountManagerService.CheckUser(email, password))
			{
				return null;
			}

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.ASCII.GetBytes(_key);
			SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
			new Claim(ClaimTypes.Email, email)
				}),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(tokenKey),
					SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

	}
}
