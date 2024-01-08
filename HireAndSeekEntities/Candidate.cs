using HireAndSeek.Entities;
using HireAndSeekEntities.Lookups;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireAndSeekEntities
{
	public class Candidate : BaseEntity ,IUser
	{
		public Candidate()
		{
		}

		public Candidate(ExperienceLevel? experienceLevel, IFormFile cv  ,int userId, User user)
		{
			ExperienceLevel = experienceLevel;
			UserId = userId;
			User = user;
			Cv = cv;
		}

		public ExperienceLevel? ExperienceLevel { get; set; }
		[NotMapped]
		public IFormFile Cv { set; get; }
		public int UserId { get; set; }
		public User User { get; }
		public ICollection<CandidateJob>? Jobs { get; set; }

	}
}
