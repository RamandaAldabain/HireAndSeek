using HireAndSeekEntities.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeekEntities.Dto
{
	public class JobDto
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "DescriptionIsRequired")]
		public string Description { get; set; }
		[Required(ErrorMessage = "ExperienceLevelIsRequired")]

		public ExperienceLevel ExperienceLevel { get; set; }
		[Required(ErrorMessage = "SalaryIsRequired")]

		public int Salary { get; set; }
		[Required(ErrorMessage = "CompanyIsRequired")]
		public int CompanyId { get; set; }
	
	}
}
