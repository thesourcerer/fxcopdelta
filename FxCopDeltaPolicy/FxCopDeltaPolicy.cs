using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.TeamFoundation.VersionControl.Client;
using CustomPolicies.CheckinAnalysis;
using System.Windows.Forms;
using System.Xml;
using CustomPolicies.FxCopDeltaPolicy.Properties;
using System.IO;

namespace CustomPolicies.FxCopDeltaPolicy
{
    [Serializable]
    public class FxCopDeltaPolicy : PolicyBase
    {
        
		#region [rgn] Fields (1)

		private static string AssemblyWatNotCompiledMessage = "The assembly \"{0}\" was not compiled since the change was made. Please rebuild your solution before performing any check-in operation.";

		#endregion [rgn]

		#region [rgn] Properties (4)

		public override string Description
        {
            get { return "Runs FxCop on the types which were modified in a check-in operation."; }
        }
		
		public override string InstallationInstructions
        {
            get { return @"To install this policy, use: c:\setup.exe"; }
        }
		
		public override string Type
        {
            get { return "FxCop Delta Policy"; }
        }
		
		public override string TypeDescription
        {
            get { return "Runs FxCop on the types which were modified in a check-in operation."; }
        }
		
		#endregion [rgn]

		#region [rgn] Methods (7)

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
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                CheckinAnalyzer checkinAnalyzer = new CheckinAnalyzer(PendingCheckin);
                FxCopCommandAdapter adapter = new FxCopCommandAdapter(Settings.Default.FxCopCommandPath);

                // Instruct the FxCopAdapter to analyze related assemblies.
                IList<string> relatedAssemblyPaths = checkinAnalyzer.GetRelatedAssemblyPaths();
                if (relatedAssemblyPaths.Count == 0)
                {
                    // No assemblies were modified, no need to evaluate.
                    return new PolicyFailure[] { };
                }
                else
                {
                    DateTime latestChangeTime = GetLatestChangeTime();
                    foreach (string assemblyPath in relatedAssemblyPaths)
                    {
                        if (!AssemblyWasCompiled(assemblyPath, latestChangeTime))
                        {
                            // If any of the assemblies wasn't built since the change was made, 
                            // the integrity of the analysis cannot be verified so a PolicyFailure is returned.
                            string fileName = Path.GetFileName(assemblyPath);
                            string message = string.Format(AssemblyWatNotCompiledMessage, fileName);
                            return new PolicyFailure[] { new PolicyFailure(message, this) };
                        }
                        else
                        {
                            adapter.AddTargetAssembly(assemblyPath);
                        }
                    }
                }

                // Instruct the FxCopAdapter to analyze the types which were modified during this checkin.
                IList<string> modifiedTypeNames = checkinAnalyzer.GetModifiedTypeNames();
                if (modifiedTypeNames.Count == 0)
                {
                    // No types were modified, no need to evaluate.
                    return new PolicyFailure[] { };
                }
                else
                {
                    foreach (string modifiedType in modifiedTypeNames)
                    {
                        adapter.AddTargetType(modifiedType);
                    }
                }

                AddCustomRuleAssemblies(adapter);
                AddDisabledRules(adapter);

                // Start the FxCopAdapter and analyze the results.
                XmlDocument results = adapter.Analyze();
                PolicyFailure[] failures = GetPolicyFailures(results);

                return failures;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
		
		// [rgn] Private Methods (5)

		/// <summary>
        /// Instructs the provided <see cref="FxCopCommandAdapter"/> to use the 
        /// custom rule assemblies which were specified in the settings dialog.
        /// </summary>
        /// <param name="adapter"></param>
        private static void AddCustomRuleAssemblies(FxCopCommandAdapter adapter)
        {
            if (Settings.Default.RuleAssemblies != null)
            {
                foreach (string ruleAssembly in Settings.Default.RuleAssemblies)
                {
                    adapter.AddRulesAssembly(ruleAssembly);
                }
            }
        }
		
		/// <summary>
        /// Instructs the provided <see cref="FxCopCommandAdapter"/> to ignore 
        /// the rules which were specified in the settings dialog.
        /// </summary>
        private static void AddDisabledRules(FxCopCommandAdapter adapter)
        {
            if (Settings.Default.DisabledRules != null)
            {
                foreach (string disabledRule in Settings.Default.DisabledRules)
                {
                    adapter.AddDisabledRule(disabledRule);
                }
            }
        }
		
		/// <summary>
        /// Determines whether an assembly has been modified after a specific time.
        /// </summary>
        /// <param name="assemblyPath">The path to the assembly to examine.</param>
        /// <param name="after">The minimal time to accept.</param>
        /// <returns><c>True</c> if the assembly has been modified after 
        /// the provided <see cref="DateTime"/>; <c>False</c> otherwise.</returns>
        private static bool AssemblyWasCompiled(string assemblyPath, DateTime after) 
        {           
            // Make sure that the assembly was built after the latest change time.
            FileInfo assemblyFileInfo = new FileInfo(assemblyPath);
            if (assemblyFileInfo.LastWriteTime < after)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
		
		/// <summary>
        /// Determines when was the latest change.
        /// </summary>
        private DateTime GetLatestChangeTime()
        {
            // Find out the time that the latest change occured.
            DateTime latestChangeTime = DateTime.MinValue;

            foreach (PendingChange pendingChange in PendingCheckin.PendingChanges.CheckedPendingChanges)
            {
                FileInfo codeFileInfo = new FileInfo(pendingChange.LocalItem);
                if (codeFileInfo.LastWriteTime > latestChangeTime)
                {
                    latestChangeTime = codeFileInfo.LastWriteTime;
                }
            }
            return latestChangeTime;
        }
		
		/// <summary>
        /// Retrieves issues from an FxCop Xml report.
        /// </summary>
        /// <param name="results">The FxCop Xml report to retrieve issues from.</param>
		private PolicyFailure[] GetPolicyFailures(XmlDocument results)
        {
            XmlNodeList issues = results.SelectNodes("//Issue");
            PolicyFailure[] failures = new PolicyFailure[issues.Count];

            for (int i = 0; i < issues.Count; i++)
            {
                XmlNode issue = issues[i];
                failures[i] = new PolicyFailure(issue.InnerText, this);
            }

            return failures;
        }
		
		#endregion [rgn]

    }
}
