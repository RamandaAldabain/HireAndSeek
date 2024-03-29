﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireAndSeek.Entities
{
	public class CandidateJob : BaseEntity
	{
		public int CandidateId { get; set; }
		public Candidate Candidate { get; set; }

		public int JobId { get; set; }
		public Job Job { get; set; }
	}
}
