using HireAndSeekEntities;
using Microsoft.EntityFrameworkCore;

namespace HireAndSeek.Data
{
	public class DatabaseContext : DbContext
	{

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<CandidateJob>().HasNoKey();
			modelBuilder.Entity<Job>().HasOne(i => i.Company).WithMany(i => i.Job).HasForeignKey(i => i.CompanyId).OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Company>().HasOne(i => i.User).WithOne().HasForeignKey<Company>(i => i.UserId).OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Company>().Property(i => i.Address).HasMaxLength(200).IsRequired();
			modelBuilder.Entity<Company>().Property(i => i.Industry).HasMaxLength(200).IsRequired();
			modelBuilder.Entity<Company>().Property(i => i.CompanySize).IsRequired();
			modelBuilder.Entity<Candidate>().HasOne(i => i.User).WithOne().HasForeignKey<Candidate>(i => i.UserId).OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Candidate>().Property(c => c.ExperienceLevel).IsRequired();

			modelBuilder.Entity<User>().Property(i => i.Email).HasMaxLength(200).IsRequired();
			modelBuilder.Entity<User>().Property(i => i.FirstName).HasMaxLength(200).IsRequired();
			modelBuilder.Entity<User>().Property(i => i.LastName).HasMaxLength(200).IsRequired();
			modelBuilder.Entity<CandidateJob>().HasKey(cj => cj.Id);

			modelBuilder.Entity<CandidateJob>()
	        .HasOne(cj => cj.Candidate)
	        .WithMany(c => c.Jobs)
	        .HasForeignKey(cj => cj.CandidateId)
	        .OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<CandidateJob>()
				.HasOne(cj => cj.Job)
				.WithMany(j => j.Candidates)
				.HasForeignKey(cj => cj.JobId)
				.OnDelete(DeleteBehavior.NoAction);
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Candidate> Candidates { get; set; }
		public DbSet<CandidateJob> CandidateJob { get; set; }
	}
}
