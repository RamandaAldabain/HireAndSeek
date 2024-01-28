using HireAndSeek.Entities.Lookups;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HireAndSeek.Entities
{
	public class CandidateDto 
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "ExperienceLevelIsRequired")]
		public ExperienceLevelEnum ExperienceLevel { get; set; }
		public IFormFile Cv { set; get; }
		public int UserId { get; set; }
		[Required(ErrorMessage = "SkillsAreRequired")]
		public List<String> Skills { get; set; }

	}
}
