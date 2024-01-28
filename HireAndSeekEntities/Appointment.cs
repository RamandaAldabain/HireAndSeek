using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Entities
{
	public class Appointment : BaseEntity
	{
		public DateTime Date { get; set; }
		public bool IsReserved { get; set; }
		public int? CandidateId { get; set; }
		public int JobId { get; set; }

		public Candidate Candidate { get; set; }
		public Job Job { get; set; }
	}
}
