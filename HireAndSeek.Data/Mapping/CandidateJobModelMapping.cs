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
	internal class CandidateJobModelMapping : IEntityTypeConfiguration<CandidateJob>
	{
		void IEntityTypeConfiguration<CandidateJob>.Configure(EntityTypeBuilder<CandidateJob> builder)
		{
			builder.HasKey(cj => cj.Id);
			builder
			.HasOne(cj => cj.Candidate)
			.WithMany(c => c.Jobs)
			.HasForeignKey(cj => cj.CandidateId)
			.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(cj => cj.Job)
				.WithMany(j => j.Candidates)
				.HasForeignKey(cj => cj.JobId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
