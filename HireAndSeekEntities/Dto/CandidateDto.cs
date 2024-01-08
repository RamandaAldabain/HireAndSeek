using HireAndSeekEntities.Lookups;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HireAndSeekEntities
{
	public class CandidateDto 
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "ExperienceLevelIsRequired")]
		public ExperienceLevel? ExperienceLevel { get; set; }
		public IFormFile Cv { set; get; }
		public int UserId { get; set; }

	}
}
