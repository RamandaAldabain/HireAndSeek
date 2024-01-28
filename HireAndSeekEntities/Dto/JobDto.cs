using HireAndSeek.Entities.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Entities.Dto
{
	public class JobDto
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "DescriptionIsRequired")]
		public string Description { get; set; }
		[Required(ErrorMessage = "ExperienceLevelIsRequired")]

		public ExperienceLevelEnum ExperienceLevel { get; set; }
		[Required(ErrorMessage = "SalaryIsRequired")]

		public int Salary { get; set; }
		[Required(ErrorMessage = "CompanyIsRequired")]
		public int CompanyId { get; set; }
		[Required(ErrorMessage = "SkillsAreRequired")]
		public List<string> Skills { get; set; }

	}
}
