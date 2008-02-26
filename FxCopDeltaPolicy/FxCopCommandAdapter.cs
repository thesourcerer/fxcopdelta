using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace CustomPolicies.FxCopDeltaPolicy
{
    public class FxCopCommandAdapter : IFxCopAdapter
    {
		
		#region [rgn] Fields (8)

		IList<string> _disabledRules;
		private readonly string _fxCopCommandPath;
		private IList<string> _rulesAssemblyPaths;
		private IList<string> _targetAssemblyPaths;
		private IList<string> _targetTypeNames;
		private const string FxCopCmdExceptionOccured = "An exception has occured while trying to run FxCopCmd.exe.\n\n{0}\n\nThe following command line arguments were used:\n\n{1}";
		private const string MustSpecifyTargetAssemblies = "You must specify at least one target assembly";
		private const string MustSpecifyTargetTypes = "You must specify at least one target type";

		#endregion [rgn]

		#region [rgn] Constructors (1)

		public FxCopCommandAdapter(string fxCopCommandPath)
        {
            _fxCopCommandPath = fxCopCommandPath;
            _rulesAssemblyPaths = new List<string>();
            _targetAssemblyPaths = new List<string>();
            _targetTypeNames = new List<string>();
            _disabledRules = new List<string>();
        }
		
		#endregion [rgn]

		#region [rgn] Methods (7)

		// [rgn] Public Methods (5)

		public void AddDisabledRule(string disabledRule)
        {
            _disabledRules.Add(disabledRule);
        }
		
		public void AddRulesAssembly(string rulesAssmeblyPath)
        {
            _rulesAssemblyPaths.Add(rulesAssmeblyPath);
        }
		
		public void AddTargetAssembly(string targetAssemblyPath)
        {
            _targetAssemblyPaths.Add(targetAssemblyPath);
        }
		
		public void AddTargetType(string targetTypeName)
        {
            _targetTypeNames.Add(targetTypeName);
        }
		
		public XmlDocument Analyze()
        {
            if (_targetAssemblyPaths.Count == 0)
            {
                throw new InvalidOperationException(MustSpecifyTargetAssemblies);
            }

            if (_targetTypeNames.Count == 0)
            {
                throw new InvalidOperationException(MustSpecifyTargetTypes);
            }

            CommandLineArguments commandLineArguments = CreateCommandLineArguments();
            Process process = CreateProcess(commandLineArguments);

            process.Start();
            process.WaitForExit();

            // Throw and exception if any errors have been reported.
            string errors = process.StandardError.ReadToEnd();
            if (errors.Length > 0)
            {
                string formattedMessage = 
                    string.Format(FxCopCmdExceptionOccured, errors, commandLineArguments.ToString());

                throw new ApplicationException(formattedMessage);
            }

            XmlDocument result = new XmlDocument();
            result.Load(commandLineArguments.OutputPath);
            return result;
        }
		
		// [rgn] Private Methods (2)

		private CommandLineArguments CreateCommandLineArguments()
        {
            CommandLineArguments commandLineArguments = new CommandLineArguments();
            commandLineArguments.TargetAssemblyPaths = _targetAssemblyPaths;
            commandLineArguments.TargetTypeNames = _targetTypeNames;
            commandLineArguments.RuleAssemblyPaths = _rulesAssemblyPaths;
            commandLineArguments.DisabledRules = _disabledRules;

            return commandLineArguments;
        }
		
		private Process CreateProcess(CommandLineArguments commandLineArguments)
        {
            Process process = new Process();
            process.StartInfo.FileName = _fxCopCommandPath;
            process.StartInfo.Arguments = commandLineArguments.ToString();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            return process;
        }
		
		#endregion [rgn]

    }    
}
