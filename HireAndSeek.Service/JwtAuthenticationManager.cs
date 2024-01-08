using HireAndSeek.Data;
using HireAndSeekEntities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
		private readonly AccountManagerService _accountManagerService;
		

	

		public JwtAuthenticationManager(string key, AccountManagerService accountManagerService)
		{
			_key = key;
			_accountManagerService = accountManagerService;
  		}

		public string Authenticate(string email, string password)
		{
			if (!_accountManagerService.ChechUser(email,password)) return null;
		

			JwtSecurityTokenHandler tokenHandler= new JwtSecurityTokenHandler();
			var tokenKey = Encoding.ASCII.GetBytes(_key);
			SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Email,email)
				}),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(tokenKey),
					SecurityAlgorithms.HmacSha256Signature) 
								
			};
			var token=tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

	}
}
