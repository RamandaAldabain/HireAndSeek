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
	public class JobModelMapping : IEntityTypeConfiguration<Job>
	{
		void IEntityTypeConfiguration<Job>.Configure(EntityTypeBuilder<Job> builder)
		{
			builder.HasOne(i => i.Company).WithMany(i => i.Job).HasForeignKey(i => i.CompanyId).OnDelete(DeleteBehavior.Restrict);

		}
	}
}
