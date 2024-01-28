using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Entities.Dto
{
	public class AppointmentDto
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public bool IsReserved { get; set; }
		public int? CandidateId { get; set; }
		public int JobId { get; set; }


	}
}
