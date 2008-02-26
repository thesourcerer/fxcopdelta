using System;
using System.Collections.Generic;

namespace CustomPolicies.CheckinAnalysis
{
    public interface ITypeLocator
    {
        IList<string> GetTypeNames(string path);
    }
}
