
using System;
using System.Collections.Generic;
using System.Text;
using WindowsProcessMonitor.Domain.Exceptions;
using WindowsProcessMonitor.Domain.Interfaces;

namespace WindowsProcessMonitor.Domain.Validation
{
    public class UserInputValidator : IValidator
    {
        private readonly List<string> errors;

        public UserInputValidator()
        {
            errors = new List<string>();
        }

        public bool Validate(params object[] values)
        {
            if (string.IsNullOrEmpty(values[0].ToString()))
                errors.Add("Process Name cannot be empty");

            if (!int.TryParse(values[1].ToString(), out int lifeTime) || (lifeTime > 60  || lifeTime <= 0))
                errors.Add("Entered life time of the processor is not valid. Please Enter a value in Minutes (between 0 and 60).");

            if (!int.TryParse(values[2].ToString(), out int frequency) || (frequency > 60 || frequency <= 0))
                errors.Add("Entered frequency is not valid. Please Enter a value in Minutes (between 0 and 60).");


            return errors.Count == 0;
        }

        public IEnumerable<string> GetErrors()
        {
            return errors;
        }
    }
}
