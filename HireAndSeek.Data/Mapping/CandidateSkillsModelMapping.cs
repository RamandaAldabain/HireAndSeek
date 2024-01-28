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
	internal class CandidateSkillsModelMapping : IEntityTypeConfiguration<CandidateSkills>
	{
		private readonly int _maxSkills;

		public CandidateSkillsModelMapping(int maxSkills)
		{
			_maxSkills = maxSkills;

		}

		void IEntityTypeConfiguration<CandidateSkills>.Configure(EntityTypeBuilder<CandidateSkills> builder)
		{
			builder.HasKey(cj => cj.Id);
			builder
			.HasOne(cj => cj.Candidate)
			.WithMany(c => c.Skills)
			.HasForeignKey(cj => cj.CandidateId)
			.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(cj => cj.Skill)
				.WithMany(j => j.Candidates)
				.HasForeignKey(cj => cj.SkillId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
