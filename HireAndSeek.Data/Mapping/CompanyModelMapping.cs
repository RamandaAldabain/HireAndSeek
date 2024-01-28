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
	public class CompanyModelMapping : IEntityTypeConfiguration<Company>
	{
		void IEntityTypeConfiguration<Company>.Configure(EntityTypeBuilder<Company> builder)
		{
			builder.Property(i => i.Address).HasMaxLength(200).IsRequired();
			builder.Property(i => i.Industry).HasMaxLength(200).IsRequired();
			builder.Property(i => i.CompanySize).IsRequired();
			builder.HasOne(i => i.User).WithOne().HasForeignKey<Company>(i => i.UserId).OnDelete(DeleteBehavior.Restrict);

		}
	}
}
