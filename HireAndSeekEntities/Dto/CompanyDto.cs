using System.ComponentModel.DataAnnotations;

namespace HireAndSeekEntities
{
	public class CompanyDto
	{
		public int? Id { get; set; }
		[Required(ErrorMessage = "AddressIsRequired")]
		public string Address { get; set; }
		[Required(ErrorMessage = "IndustryIsRequired")]

		public string Industry { get; set; }
		[Required(ErrorMessage = "CompanySizeIsRequired")]

		public int CompanySize { get; set; }

		public int UserId { get; set; }
		
		public int JobId { get; set; }
	}
}
