using HireAndSeek.Entities.Dto;
using HireAndSeek.Data;
using HireAndSeek.Entities.Lookups;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace HireAndSeek.Entities
{
	public class UserDto 
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "EmailIsRequired")]
	
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

		public RolesEnum Role { get; set; }

		public IFormFile ProfilePicture { set; get; }
		[RequiredIf("Role", new Object[] { RolesEnum.Company }, "FIELD_IS_REQUIRED")]
		public CompanyDto Company { get; set; }
		[RequiredIf("Role", new Object[] { RolesEnum.Candidate }, "FIELD_IS_REQUIRED")]
		public CandidateDto Candidate { get; set; }
	}
}
