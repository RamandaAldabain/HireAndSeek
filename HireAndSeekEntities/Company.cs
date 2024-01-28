
using HireAndSeek.Entities;
using System.Collections.Generic;

namespace HireAndSeek.Entities
{
	public class Company : BaseEntity 
	{

		public string Address { get; set; }
		public string Industry { get; set; }
		public int CompanySize { get; set; }

		public int UserId { get; set; }

		public User User { get; }

		public ICollection<Job> Job { get; set; }
	}

	
}
