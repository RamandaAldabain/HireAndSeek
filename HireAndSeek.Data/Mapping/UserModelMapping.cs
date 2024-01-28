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
	public class UserModelMapping : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{

			builder.Property(i => i.Email).HasMaxLength(200).IsRequired();
			builder.HasIndex(x => new { x.Email }).IsUnique();
			builder.Property(i => i.FirstName).HasMaxLength(200).IsRequired();
			builder.Property(i => i.LastName).HasMaxLength(200).IsRequired();
			builder.HasOne(x => x.PictureFile).WithOne().HasForeignKey<User>(i => i.FileId).OnDelete(DeleteBehavior.Restrict);



		}
	}
}
