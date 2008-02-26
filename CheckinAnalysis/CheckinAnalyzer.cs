using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.TeamFoundation.VersionControl.Client;
using EnvDTE80;
using EnvDTE;
using System.IO;

namespace CustomPolicies.CheckinAnalysis
{
    public class CheckinAnalyzer
    {
		
		#region [rgn] Fields (2)

		private readonly IPendingCheckin _pendingCheckin;
		private readonly ITypeLocator _typeLocator;

		#endregion [rgn]

		#region [rgn] Constructors (2)

		public CheckinAnalyzer(IPendingCheckin pendingCheckin, ITypeLocator typeLocator)
        {
            _pendingCheckin = pendingCheckin;
            _typeLocator = typeLocator;
        }
		
		public CheckinAnalyzer(IPendingCheckin pendingCheckin) : this(pendingCheckin, new TypeLocator())
        {
        }
		
		#endregion [rgn]

		#region [rgn] Methods (6)

		// [rgn] Public Methods (2)

		public IList<string> GetModifiedTypeNames()
        {
            List<string> modifiedTypeNames = new List<string>();

            foreach (PendingChange pendingChange in _pendingCheckin.PendingChanges.CheckedPendingChanges)
            {
                if ((pendingChange.ChangeType & ChangeType.Add) == ChangeType.Add ||
                    (pendingChange.ChangeType & ChangeType.Edit) == ChangeType.Edit)
                {
                    string path = pendingChange.LocalItem;
                    if (path.EndsWith(".cs") && File.Exists(path))
                    {
                        modifiedTypeNames.AddRange(_typeLocator.GetTypeNames(path));
                    }
                }
            }

            return modifiedTypeNames;
        }
		
		public IList<string> GetRelatedAssemblyPaths()
        {
            List<string> relatedAssemblyPaths = new List<string>();

            IServiceProvider serviceProvider = (IServiceProvider)_pendingCheckin;
            DTE dte = (DTE)serviceProvider.GetService(typeof(DTE));

            Solution solution = dte.Solution;
            foreach (Project project in solution.Projects)
            {
                if (project.ConfigurationManager != null)
                {
                    string assemblyPath = GetAssemblyPath(project);
                    if (File.Exists(assemblyPath))
                    {
                        relatedAssemblyPaths.Add(assemblyPath);
                    }
                }
            }

            return relatedAssemblyPaths;
        }
		
		// [rgn] Private Methods (4)

		private string GetAssemblyPath(Project project)
        {
            string fullPath = GetFullPath(project);
            string outputPath = GetOutputPath(project);
            string targetPath = Path.Combine(fullPath, outputPath);

            string outputFileName = GetOutputFileName(project);
            string assemblyPath = Path.Combine(targetPath, outputFileName);

            return assemblyPath;
        }
		
		private static string GetFullPath(Project project)
        {
            try
            {
                return project.Properties.Item("FullPath").Value.ToString();
            }
            catch
            {
                // The project probably does not have a FullPath property.
                return string.Empty;
            }
        }
		
		private static string GetOutputFileName(Project project)
        {
            try
            {
                return project.Properties.Item("OutputFileName").Value.ToString();
            }
            catch
            {
                // The project probably does not have a OutputFileName property.
                return string.Empty;
            }
        }
		
		private static string GetOutputPath(Project project)
        {
            try
            {
                return project.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value.ToString();
            }
            catch
            {
                // The active configuration probably does not have a OutputPath property.
                return string.Empty;
            }
        }
		
		#endregion [rgn]

    }
}
