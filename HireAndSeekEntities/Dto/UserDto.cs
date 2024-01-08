using HireAndSeekEntities.Lookups;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace HireAndSeekEntities
{
	public class UserDto 
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "EmailIsRequired")]
		[EmailAddress]
		[RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Invalid Email Address")]
		public string Email {get; set;}
		[Required(ErrorMessage = "FirstNameIsRequired")]

		public string FirstName {get; set;}
		[Required(ErrorMessage = "LastNameIsRequired")]

		public string LastName {get; set;}
		[Required(ErrorMessage = "PasswordIsRequired")]

		public string Password { get; set; }
		[Required(ErrorMessage = "ConfirmPasswordIsRequired")]

		public string ConfirmPassword { get; set; }
		[Required(ErrorMessage = "RoleIsRequired")]

		public RolesLookup Role { get; set; }
		[NotMapped]
		public IFormFile ProfilePicture { set; get; }

		public CompanyDto? Company { get; set; }
		public CandidateDto? Candidate { get; set; }
	}
}
