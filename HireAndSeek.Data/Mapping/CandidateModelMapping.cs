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
	internal class CandidateModelMapping : IEntityTypeConfiguration<Candidate>
	{
		void IEntityTypeConfiguration<Candidate>.Configure(EntityTypeBuilder<Candidate> builder)
		{
			builder.HasOne(i => i.User).WithOne().HasForeignKey<Candidate>(i => i.UserId).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(i => i.CvFile).WithOne().HasForeignKey<Candidate>(i => i.FileId).OnDelete(DeleteBehavior.Restrict);
			builder.Property(c => c.ExperienceLevel).IsRequired();

		}
	}
}
