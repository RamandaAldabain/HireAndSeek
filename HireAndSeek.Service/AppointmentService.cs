using HireAndSeek.Data;
using HireAndSeek.Entities;
using HireAndSeek.Entities.Dto;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Service
{
	public class AppointmentService
	{
		private readonly DatabaseContext _dbContext;

		public AppointmentService(DatabaseContext db)
		{
			_dbContext = db;
		}
		public async Task<AppointmentDto> CreateAppointment(AppointmentDto createAppointmentDto)
		{
			var job = await _dbContext.Jobs.FindAsync(createAppointmentDto.JobId);
			if (job == null)
			{
				throw new Exception("Job not found");
			}

			var appointment = new Appointment
			{
				JobId = createAppointmentDto.JobId,
				Date = createAppointmentDto.Date,
				IsReserved = false


			};

			_dbContext.Appointments.Add(appointment);
			await _dbContext.SaveChangesAsync();
			var appointmentDto = appointment.Adapt<AppointmentDto>();


			return appointmentDto;
		}


		public async Task<AppointmentDto> GetAppointment(AppointmentDto model)
		{
			var appointment = await _dbContext.Appointments.FindAsync(model.Id);
			if(appointment.IsReserved) throw new Exception("Appointment Taken please choose another one");
			if (appointment == null)
			{
				throw new Exception("appointment not found");
			}
			appointment.CandidateId = model.CandidateId;
			appointment.IsReserved = true;

			var appointmentDto = appointment.Adapt<AppointmentDto>();

			return appointmentDto;
		}
	}

}

