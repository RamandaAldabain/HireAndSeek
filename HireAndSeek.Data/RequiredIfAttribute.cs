using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireAndSeek.Data
{

	public class RequiredIfAttribute : RequiredAttribute
	{
		private string DependentPropertyName { get; set; }
		private object[] RequiredValues { get; set; }

		public RequiredIfAttribute(string dependentPropertyName, object[] requiredValues, string errorMessage = "")
		{
			DependentPropertyName = dependentPropertyName;
			RequiredValues = requiredValues;
			ErrorMessage = errorMessage;
		}

		protected override ValidationResult IsValid(object value, ValidationContext context)
		{
			var instance = context.ObjectInstance;
			var type = instance.GetType();
			var dependentPropertyValue = type.GetProperty(DependentPropertyName)?.GetValue(instance, null);

			if (dependentPropertyValue != null && Array.Exists(RequiredValues, x => x.Equals(dependentPropertyValue)))
			{
				ValidationResult result = base.IsValid(value, context);
				return result;
			}

			return ValidationResult.Success;
		}
	}

}
