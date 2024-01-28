using HireAndSeek.Entities.Lookups;

namespace HireAndSeek.Entities
{
	public class Job : BaseEntity
	{
		public string Description { get; set; }
		public ExperienceLevelEnum ExperienceLevel { get; set; }
		public int Salary { get; set; }
		public int CompanyId { get; set; }
		public Company Company { get; set; }

		public ICollection<CandidateJob> Candidates { get; set; }
		public ICollection<JobSkills> Skills { get; set; }
		public ICollection<Appointment> Appointments { get; set; }

	}
}
