using HireAndSeekEntities.Lookups;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireAndSeekEntities
{
	public class User : BaseEntity
	{
		public string Email {get; set;}
		public string FirstName {get; set;}
		public string LastName {get; set;}
		public string Password {get; set;}
		public RolesLookup Role { get; set; }
		[NotMapped]
		public IFormFile ProfilePicture { set; get; }
	}
}
