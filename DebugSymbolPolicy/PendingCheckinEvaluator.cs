using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.TeamFoundation.VersionControl.Client;
using System.Xml;
using System.Text.RegularExpressions;

namespace CustomPolicies.DebugSymbolsPolicy
{
    public static class PendingCheckinEvaluator
    {
        
		#region [rgn] Fields (1)

		private const string buildConfigurationPattern = @"\s'\$\(Configuration\)\|\$\(Platform\)'\s==\s'(?<Configuration>.*)\|AnyCPU'\s";

		#endregion [rgn]

		#region [rgn] Methods (4)

		// [rgn] Public Methods (1)

		public static PolicyFailure[] Evaluate(IPendingCheckin pendingCheckin, IPolicyEvaluation policyEvaluation)
        {
            List<PolicyFailure> failures = new List<PolicyFailure>();

            // Iterate over all changes to files that end with ".csproj".
            foreach (PendingChange pendingChange in GetCheckedPendingProjects(pendingCheckin))
            {
                // Examine the csproj file and validate all constraints.
                // Start by reading the csproj into an XmlDocument.
                XmlDocument csprojDocument = new XmlDocument();
                csprojDocument.Load(pendingChange.LocalItem);

                // Iterate over all of this project's build configurations.
                foreach (XmlNode node in GetBuildConfigurationNodes(csprojDocument))
                {
                    // Get the build configuration's name.
                    string configurationName = node.Attributes["Condition"].InnerText;

                    // Get the build configuration's debug symbol type.
                    string debugType = node["DebugType"].InnerText;

                    // Check if any constraint is unsatisfied with this build configuration.
                    foreach (DebugSymbolConstraint unsatisfiedConstraint in GetUnsatisfiedConstraints(configurationName, debugType))
                    {
                        // A constraint is unsatisfied with this project's build configuration. Report a failure.
                        string message = string.Format("Project '{0}' does not satisfy the constraint '{1}'.",
                            pendingChange.FileName,
                            unsatisfiedConstraint);

                        PolicyFailure failure = new PolicyFailure(message, policyEvaluation);
                        failures.Add(failure);
                    }
                }
            }

            return failures.ToArray();
        }
		
		// [rgn] Private Methods (3)

		/// <summary>
        /// Retrieves <see cref="XmlNode"/> instances which describe build configurations.
        /// </summary>
		private static IEnumerable<XmlNode> GetBuildConfigurationNodes(XmlDocument projectDocument)
        {
            // Create a namespace manager to browse the project document using an XPath navigator.
            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(projectDocument.NameTable);
            namespaceManager.AddNamespace("ms", "http://schemas.microsoft.com/developer/msbuild/2003");

            // Iterate through each "PropertyGroup" element in the project document.
            string query = "ms:Project/ms:PropertyGroup";
            foreach (XmlNode node in projectDocument.SelectNodes(query, namespaceManager))
            {
                // If the PropertyGroup has a "Condition" attribute who'se value matches 
                // the condition pattern, it describes a build configuration.
                XmlAttribute conditionAttribute = node.Attributes["Condition"];
                if (conditionAttribute != null)
                {
                    string condition = conditionAttribute.Value;
                    // Check if the condition matches the build configuration pattern.
                    Regex regex = new Regex(buildConfigurationPattern);
                    Match match = regex.Match(condition);
                    if (regex.IsMatch(condition))
                    {
                        // This node describes a build configuration.
                        yield return node;
                    }
                }
            }
        }
		
		/// <summary>
        /// Gets all <see cref="PendingChange"/> instances for "*.csproj" files.
        /// </summary>
		private static IEnumerable<PendingChange> GetCheckedPendingProjects(IPendingCheckin pendingCheckin)
        {
            foreach (PendingChange pendingChange in pendingCheckin.PendingChanges.CheckedPendingChanges)
            {
                string projectFileName = pendingChange.FileName;
                if (projectFileName.EndsWith(".csproj"))
                {
                    yield return pendingChange;
                }
            }
        }
		
		/// <summary>
        /// Validates a configuration against all <see cref="DebugSymbolConstraint"/> saved in the constraints 
        /// file and checks which of the <see cref="DebugSymbolConstraint"/> are unsatisfied with it.
        /// </summary>
        /// <remarks>
        /// A configuration is considered invalid only if it matches the name of a constraint but does not match 
        /// the requested debug type of that constraint.
        /// </remarks>
		private static IEnumerable<DebugSymbolConstraint> GetUnsatisfiedConstraints(string configurationName, string debugType)
        {
            DebugSymbolConstraintCollection constraints = DebugSymbolConstraintCollection.Load();

            foreach (DebugSymbolConstraint constraint in constraints)
            {
                // Is the constraint's configuration name contained in "configuration"?
                bool configurationNameContained = configurationName.Contains(constraint.ConfigurationName);
                if (configurationNameContained)
                {
                    // Is the constraint's requested debug type the same as "debugType"?
                    string requestedDebugInfo = constraint.RequestedDebugInfo.ToString().ToLower();
                    bool debugTypeMatches = debugType.Equals(requestedDebugInfo);

                    if (!debugTypeMatches)
                    {
                        // This constraint is unsatisfied.
                        yield return constraint;
                    }
                }
            }
        }
		
		#endregion [rgn]

    }
}
