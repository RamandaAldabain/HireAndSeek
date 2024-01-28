using HireAndSeek.Data.Mapping;
using HireAndSeek.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HireAndSeek.Data
{
	public class DatabaseContext : DbContext
	{
		private readonly int _maxSkills;

		public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
		{
			_maxSkills = configuration.GetSection("SkillLimitConfig:MaxSkills").GetValue<int>("MaxSkills");

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
			modelBuilder.ApplyConfiguration(new JobSkillsModelMapping(_maxSkills));
			modelBuilder.ApplyConfiguration(new CandidateSkillsModelMapping(_maxSkills));


		}
		public DbSet<User> Users { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Candidate> Candidates { get; set; }
		public DbSet<CandidateJob> CandidateJob { get; set; }
		public DbSet<CandidateSkills> CandidateSkills { get; set; }
		public DbSet<JobSkills> JobSkills { get; set; }
		public DbSet<FileDetails> FileDetails { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
	}
}
