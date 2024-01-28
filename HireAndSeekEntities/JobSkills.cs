using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Entities
{
	public class JobSkills : BaseEntity
	{
		public JobSkills(int jobId,int skillId)
		{
			SkillId = skillId;
			JobId = jobId;
		}

		public int SkillId { get; set; }
		public Skill Skill { get; set; }

		public int JobId { get; set; }
		public Job Job { get; set; }
	}
}
