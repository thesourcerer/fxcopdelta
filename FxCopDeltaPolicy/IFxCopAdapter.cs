using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CustomPolicies.FxCopDeltaPolicy
{
    public interface IFxCopAdapter
    {
        void AddTargetAssembly(string targetAssemblyPath);
        void AddTargetType(string targetTypeName);
        void AddRulesAssembly(string rulesAssmeblyPath);
        XmlDocument Analyze();
    }
}
