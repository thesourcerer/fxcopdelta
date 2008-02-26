using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CustomPolicies.DebugSymbolsPolicy
{
    public class DebugSymbolConstraint
    {
		
		#region [rgn] Fields (2)

		private string _configurationName;
		private DebugInfo _requestedDebugInfo;

		#endregion [rgn]

		#region [rgn] Constructors (2)

		public DebugSymbolConstraint(string configurationName, DebugInfo requestedDebugInfo)
        {
            _configurationName = configurationName;
            _requestedDebugInfo = requestedDebugInfo;
        }
		
		public DebugSymbolConstraint() { }
		
		#endregion [rgn]

		#region [rgn] Properties (2)

		public string ConfigurationName
        {
            get { return _configurationName; }
            set { _configurationName = value; }
        }
		
		public DebugInfo RequestedDebugInfo
        {
            get { return _requestedDebugInfo; }
            set { _requestedDebugInfo = value; }
        }
		
		#endregion [rgn]

		#region [rgn] Methods (1)

		// [rgn] Public Methods (1)

		public override string ToString()
        {
            string formattedDebugInfo;

            switch (_requestedDebugInfo)
            {
                case DebugInfo.False:
                    formattedDebugInfo = "no debug symbols";
                    break;
                case DebugInfo.PdbOnly:
                    formattedDebugInfo = "PDB's only";
                    break;
                case DebugInfo.Full:
                    formattedDebugInfo = "complete debug information";
                    break;
                default:
                    throw new NotSupportedException();
            }

            return string.Format("Assemblies built under '{0}' should come with {1}.", _configurationName, formattedDebugInfo);
        }
		
		#endregion [rgn]

    }
}
