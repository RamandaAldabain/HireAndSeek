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
	public class AppointmentModelMapping : IEntityTypeConfiguration<Appointment>
	{
		public void Configure(EntityTypeBuilder<Appointment> builder)
		{
			builder.HasKey(a => new { a.CandidateId, a.JobId });
			builder
				   .HasOne(a => a.Candidate)
				   .WithMany(u => u.Appointments)
				   .HasForeignKey(a => a.CandidateId);

			builder
				.HasOne(a => a.Job)
				.WithMany(j => j.Appointments)
				.HasForeignKey(a => a.JobId);

		}
	}
}
