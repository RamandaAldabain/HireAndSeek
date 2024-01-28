using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Entities
{
	public class Skill : BaseEntity
	{
		public string Name { get; set; }
		public ICollection<JobSkills> Jobs { get; set; }
		public ICollection<CandidateSkills> Candidates { get; set; }

	}
}
