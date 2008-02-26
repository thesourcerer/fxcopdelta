using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.TeamFoundation.VersionControl.Client;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;

namespace CustomPolicies.DebugSymbolsPolicy
{
    [Serializable]
    public class DebugSymbolsPolicy : PolicyBase
    {
		
		#region [rgn] Properties (4)

		public override string Description
        {
            get { return "Assures that debug symbols are attached to compiled assemblies."; }
        }
		
		public override string InstallationInstructions
        {
            get { return @"To install this policy, use: C:\setup.exe"; }
        }
		
		public override string Type
        {
            get { return "Debug Symbols Policy"; }
        }
		
		public override string TypeDescription
        {
            get { return "Assures that debug symbols are attached to compiled assemblies."; }
        }
		
		#endregion [rgn]

		#region [rgn] Methods (2)

		// [rgn] Public Methods (2)

		public override bool Edit(IPolicyEditArgs policyEditArgs)
        {
            using (SettingsForm settingsForm = new SettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
		
		public override PolicyFailure[] Evaluate()
        {
            return PendingCheckinEvaluator.Evaluate(PendingCheckin, this);
        }
		
		#endregion [rgn]

    }
}
