

using System.Collections.Generic;

namespace WindowsProcessMonitor.Domain.Interfaces
{
    public interface IValidator
    {
        bool Validate(params object[] values);

        IEnumerable<string> GetErrors();
    }
}
