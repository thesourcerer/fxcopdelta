using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CustomPolicies.FxCopDeltaPolicy
{
    public class CommandLineArguments
    {
		
		#region [rgn] Fields (5)

		private IList<string> _disabledRules;
		private readonly string _outputPath;
		private IList<string> _ruleAssemblyPaths;
		private IList<string> _targetAssemblyPaths;
		private IList<string> _targetTypeNames;

		#endregion [rgn]

		#region [rgn] Constructors (1)

		public CommandLineArguments()
        {
            _outputPath = Path.GetTempFileName();
            _ruleAssemblyPaths = new List<string>();
            _targetAssemblyPaths = new List<string>();
            _targetTypeNames = new List<string>();
            _disabledRules = new List<string>();
        }
		
		#endregion [rgn]

		#region [rgn] Properties (5)

		public IList<string> DisabledRules
        {
            get { return _disabledRules; }
            set { _disabledRules = value; }
        }
		
		public string OutputPath
        {
            get { return _outputPath; }
        }
		
		public IList<string> RuleAssemblyPaths
        {
            get { return _ruleAssemblyPaths; }
            set { _ruleAssemblyPaths = value; }
        }
		
		public IList<string> TargetAssemblyPaths
        {
            get { return _targetAssemblyPaths; }
            set { _targetAssemblyPaths = value; }
        }
		
		public IList<string> TargetTypeNames
        {
            get { return _targetTypeNames; }
            set { _targetTypeNames = value; }
        }
		
		#endregion [rgn]

		#region [rgn] Methods (5)

		// [rgn] Public Methods (1)

		public override string ToString()
        {
            string targetAssemblies = GetTargetAssemblies();
            string ruleAssemblies = GetRuleAssemblies();
            string targetTypes = GetTargetTypes();
            string disabledRules = GetDisabledRules();

            string arguments =
                string.Format("{0} {1} {2} {3} /out:\"{4}\"", targetAssemblies, ruleAssemblies, targetTypes, disabledRules, _outputPath);

            return arguments;
        }
		
		// [rgn] Private Methods (4)

		private string GetDisabledRules()
        {
            StringBuilder disabledRules = new StringBuilder();
            foreach (string disabledRule in _disabledRules)
            {
                string formattedDisabledRule = string.Format("/ruleid:-{0} ", disabledRule);
                disabledRules.Append(formattedDisabledRule);
            }
            return disabledRules.ToString();
        }
		
		private string GetRuleAssemblies()
        {
            StringBuilder ruleAssemblies = new StringBuilder();
            foreach (string ruleAssembly in _ruleAssemblyPaths)
            {
                string formattedRuleAssembly = string.Format("/rule:\"{0}\" ", ruleAssembly);
                ruleAssemblies.Append(formattedRuleAssembly);
            }
            return ruleAssemblies.ToString();
        }
		
		private string GetTargetAssemblies()
        {
            StringBuilder targetAssemblies = new StringBuilder();
            foreach (string targetAssembly in _targetAssemblyPaths)
            {
                string formattedTargetAssembly = string.Format("/file:\"{0}\" ", targetAssembly);
                targetAssemblies.Append(formattedTargetAssembly);
            }
            return targetAssemblies.ToString();
        }
		
		private string GetTargetTypes()
        {
            StringBuilder targetTypes = new StringBuilder("/types:");
            foreach (string targetType in _targetTypeNames)
            {
                string formattedTargetType = string.Format(",{0}", targetType);
                targetTypes.Append(formattedTargetType);
            }
            return targetTypes.ToString();
        }
		
		#endregion [rgn]

    }
}
