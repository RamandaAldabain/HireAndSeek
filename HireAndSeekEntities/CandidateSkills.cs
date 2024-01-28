using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Entities
{
	public class CandidateSkills : BaseEntity
	{
		public int SkillId { get; set; }
		public Skill Skill { get; set; }

		public int CandidateId { get; set; }
		public Candidate Candidate { get; set; }
	}
}
