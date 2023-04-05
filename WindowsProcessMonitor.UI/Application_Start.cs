
using Serilog;
using System;
using System.Text;
using System.Linq;
using WindowsProcessMonitor.Domain.Interfaces;
using WindowsProcessMonitor.Domain.Exceptions;
using WindowsProcessMonitor.UI.Job;

namespace WindowsProcessMonitor.UI
{
    public class Application_Start : IApplication_Start
    {
        private readonly IValidator _validator;

        public Application_Start(IValidator validator)
        {
            _validator = validator;
        }

        public void Run(params object[] values)
        {
            try
            {
                if (!_validator.Validate(values))
                {
                    var errors = _validator.GetErrors().ToList();
                    var sbError = new StringBuilder();
                    errors.ForEach(e => sbError.AppendFormat("{0}\n", e));
                    Console.WriteLine(sbError);
                    
                    throw new ValidationException($"Invalid Inputs :\n{sbError}");
                }

                CronJob.InitializeJob(values);

            }
            catch (Exception ex) 
            {
                Log.Error($"Error while processing Job. Error : {ex}");
            }
        }
    }
}
