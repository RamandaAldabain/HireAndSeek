using HireAndSeek.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Data.Mapping
{
	internal class JobSkillsModelMapping : IEntityTypeConfiguration<JobSkills>
	{
		private readonly int _maxSkills;

		public JobSkillsModelMapping(int maxSkills)
		{
			_maxSkills = maxSkills;

		}

		void IEntityTypeConfiguration<JobSkills>.Configure(EntityTypeBuilder<JobSkills> builder)
		{
			builder.HasKey(cj => cj.Id);
			builder
			.HasOne(cj => cj.Skill)
			.WithMany(c => c.Jobs)
			.HasForeignKey(cj => cj.SkillId)
			.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(cj => cj.Job)
				.WithMany(j => j.Skills)
				.HasForeignKey(cj => cj.JobId)
				.OnDelete(DeleteBehavior.NoAction);

		}
	}
}
