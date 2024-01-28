using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HireAndSeek.Entities.ValidationHelpers.AppointmentHourRange;

namespace HireAndSeek.Entities.Dto
{
	public class AppointmentDto
	{
		public int Id { get; set; }
		[ValidateHourRange]

		public DateTime Date { get; set; }
		public bool IsReserved { get; set; }
		public int? CandidateId { get; set; }
		public int JobId { get; set; }


	}
}
