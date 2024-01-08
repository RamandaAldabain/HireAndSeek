﻿using HireAndSeekEntities.Lookups;
using System.ComponentModel.DataAnnotations;

namespace HireAndSeekEntities
{
    public class BaseEntity
	{
		public int Id { get; set; }
	    public DateTime	CreationDate { get; set; }
	    public int	CreatedBy { get; set; }
		public int UpdatedBy { get; set;}
		public int IsDeleted { get; set; }
	}
}
