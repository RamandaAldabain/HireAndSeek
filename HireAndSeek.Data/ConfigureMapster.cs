using HireAndSeek.Entities;
using HireAndSeek.Entities.Dto;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Data
{
	public  class ConfigureMapster
	{
		public static void Configure()
		{
			TypeAdapterConfig<User, UserDto>.NewConfig()
				.Map(dest => dest.Id, src => src.Id)  // Assuming Id is a property in the UserDto class
				.Map(dest => dest.Email, src => src.Email)
				.Map(dest => dest.FirstName, src => src.FirstName)
				.Map(dest => dest.LastName, src => src.LastName)
				.Map(dest => dest.Password, src => src.Password)
				.Map(dest => dest.Role, src => src.Role)
				.Ignore(dest=> dest.ConfirmPassword)
				.Ignore(dest=> dest.Company)
				.Ignore(dest=> dest.ProfilePicture)
				.Ignore(dest=> dest.Candidate);



			TypeAdapterConfig<UserDto, User>.NewConfig()
				.Map(dest => dest.Email, src => src.Email)
				.Map(dest => dest.FirstName, src => src.FirstName)
				.Map(dest => dest.LastName, src => src.LastName)
				.Map(dest => dest.Password, src => src.Password)
				.Map(dest => dest.Role, src => src.Role);
				//.Map(dest => dest.ProfilePicture, src => src.ProfilePicture)
				//.Ignore(dest => dest.ProfilePicture);

			TypeAdapterConfig<CompanyDto, CompanyDto>.NewConfig()
				.Map(dest => dest.Id, src => src.Id)
				.Map(dest => dest.UserId, src => src.UserId)
				;
			
			TypeAdapterConfig<CompanyDto, CompanyDto>.NewConfig()
				.Map(dest => dest.Id, src => src.Id)
				.Map(dest => dest.UserId, src => src.UserId);

			//TypeAdapterConfig<CandidateDto, Candidate>.NewConfig()
			//	.Ignore(dest => dest.Cv);

			TypeAdapterConfig<Candidate, CandidateDto>.NewConfig()
				.Ignore(dest => dest.Cv);

			TypeAdapterConfig<Job, JobDto>.NewConfig();

			TypeAdapterConfig<JobDto, Job>.NewConfig().Ignore(i=>i.Skills);
			TypeAdapterConfig<Appointment, AppointmentDto>.NewConfig();

		}
	}
}
