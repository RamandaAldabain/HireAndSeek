
using HireAndSeek.Entities;
using System.Collections.Generic;

namespace HireAndSeekEntities
{
	public class Company : BaseEntity , IUser
	{
		public Company()
		{
		}

		public Company(string address, string industry, int companySize, int userId, User user)
		{
			Address = address;
			Industry = industry;
			CompanySize = companySize;
			UserId = userId;
			this.User = user;

		}

		public string Address { get; set; }
		public string Industry { get; set; }
		public int CompanySize { get; set; }

		public int UserId { get; set; }

		public User User { get; }

		public int? JobId { get; set; }
		public ICollection<Job>? Job { get; set; }
	}

	
}
