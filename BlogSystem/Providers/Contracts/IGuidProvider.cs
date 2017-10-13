using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Contracts
{
    public interface IGuidProvider
    {
        Guid CreateGuid();

        Guid CreateGuidFromString(string input);
    }
}
