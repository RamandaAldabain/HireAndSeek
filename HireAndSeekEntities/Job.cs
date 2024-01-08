using HireAndSeekEntities.Lookups;

namespace HireAndSeekEntities
{
	public class Job : BaseEntity
	{
		public string Description { get; set; }
		public ExperienceLevel ExperienceLevel { get; set; }
		public int Salary { get; set; }
		public int CompanyId { get; set; }
		public Company Company { get; set; }

		public ICollection<CandidateJob> Candidates { get; set; }
	}
}
