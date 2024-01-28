using HireAndSeek.Entities;
using HireAndSeek.Entities.Lookups;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireAndSeek.Entities
{
	public class Candidate : BaseEntity
	{
	

		public ExperienceLevelEnum? ExperienceLevel { get; set; }
	
		public int UserId { get; set; }
		public User User { get; }
		public int FileId { get; set; }
		public FileDetails CvFile { get; }
		public ICollection<CandidateJob> Jobs { get; set; }
		public ICollection<CandidateSkills> Skills { get; set; }
		public ICollection<Appointment> Appointments { get; set; }


	}
}
