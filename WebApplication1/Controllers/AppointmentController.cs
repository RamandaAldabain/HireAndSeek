using HireAndSeek.Data;
using HireAndSeek.Entities.Dto;
using HireAndSeek.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireAndSeek.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AppointmentController : ControllerBase
	{
		public readonly DatabaseContext _dbContext;
		public readonly AppointmentService _appointmentService;

		public AppointmentController(DatabaseContext db, AppointmentService appointmentService)
		{
			_dbContext = db;
			_appointmentService = appointmentService;
		}
		[HttpPost]
		public async Task<AppointmentDto> MakeAppointmentAsync(AppointmentDto model)
		{
			if(ModelState.IsValid) { 
			var result=await _appointmentService.GetAppointment(model);
			return result;
			
			} else
			{
				throw new InvalidOperationException("Invalid Model");
			}
		}
		[HttpPost]
		public async Task<AppointmentDto> CreateAppointment(AppointmentDto model)
		{
			if (ModelState.IsValid)
			{
				var result = await _appointmentService.CreateAppointment(model);
				return result;

			}
			else
			{
				throw new InvalidOperationException("Invalid Model");
			}
		}

	}
}
