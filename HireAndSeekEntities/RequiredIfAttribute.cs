using HireAndSeek.Entities;
using HireAndSeek.Entities.Lookups;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Data
{

		public class RequiredIfAttribute : RequiredAttribute
	{
			private String PropertyName { get; set; }
			private Object[] DesiredValue { get; set; }

			public RequiredIfAttribute(String propertyName, Object[] desiredvalue, string errorMessage = "")
			{
				PropertyName = propertyName;
				DesiredValue = desiredvalue;
				ErrorMessage = errorMessage;
			}

			protected override ValidationResult IsValid(object value, ValidationContext context)
			{
				Object instance = context.ObjectInstance;
				Type type = instance.GetType();
				Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
				if (DesiredValue is ICollection)
				{
					IList DesiredValueList = DesiredValue as IList;
					if (DesiredValueList.Count != 0)
					{
						if (DesiredValueList.Contains(proprtyvalue))
						{
							ValidationResult result = base.IsValid(value, context);
							return result;
						}
					}
				}

				else if (
					 (proprtyvalue == null && (DesiredValue == null || string.IsNullOrWhiteSpace(DesiredValue.ToString()))) ||
					 (DesiredValue == null && (proprtyvalue == null || string.IsNullOrWhiteSpace(proprtyvalue?.ToString()))) ||
					 proprtyvalue?.ToString() == DesiredValue.ToString())
				{

					ValidationResult result = base.IsValid(value, context);
					return result;
				}
				return ValidationResult.Success;
			}

		}
	}