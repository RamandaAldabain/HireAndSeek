using HireAndSeek.Entities.Lookups;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireAndSeek.Entities
{
	public class User : BaseEntity
	{
		public string Email {get; set;}
		public string FirstName {get; set;}
		public string LastName {get; set;}
		public string Password {get; set;}
		public RolesEnum Role { get; set; }
		public int FileId { get; set; }
		public FileDetails PictureFile { get; }
	}
}
