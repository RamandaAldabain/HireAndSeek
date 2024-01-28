using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Entities.ValidationHelpers
{
	public class AppointmentHourRange
	{
		public class ValidateHourRange : ValidationAttribute
		{
			private static int[] HoursRange;
		

			public ValidateHourRange()
			{
				

			}
			public static void InitializeValidHours(IConfiguration configuration)
			{
				HoursRange = configuration.GetSection("LimitConfig:AppointmentHours").Get<int[]>();
			}
			protected override ValidationResult IsValid(object value, ValidationContext validationContext)
			{
				if (value is DateTime dateTime)
				{
					int hour = dateTime.Hour;
					if (HoursRange.Contains(hour))
					{
						return ValidationResult.Success;
					}
				}

				return new ValidationResult("Not a valid time for appointment");
			}
		}
	}
}
