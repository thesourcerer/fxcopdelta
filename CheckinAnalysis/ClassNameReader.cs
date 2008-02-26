using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomPolicies.CheckinAnalysis
{
    /// <summary>
    /// Reads names of classes found in a C# code block.
    /// </summary>
    public class ClassNameReader : IElementNameReader
    {
        
		#region [rgn] Fields (1)

		private const string ClassPattern = @"(?:((?:public|private|internal|abstract|sealed|static|partial)\s*))*class\s*(?<Name>\w+)(?:[\w.,\:\<\>\?]*\s*)*\{[^\{\}]*(?:(?:(?<Open>\{)[^\{\}]*)+(?:(?<Close-Open>\})[^\{\}]*)+)*(?(Open)(?!))\}";

		#endregion [rgn]

		#region [rgn] Methods (1)

		// [rgn] Public Methods (1)

		/// <summary>
        /// Retrieve names of all class instances from the specified code block.
        /// </summary>
        /// <param name="code">The code to retrieve names from.</param>
        /// <returns>A list of class names found in the code block.</returns>
        public IList<string> RetrieveNames(string code)
        {
            Regex regex = new Regex(ClassPattern);
            Match match = regex.Match(code);

            IList<string> classNames = new List<string>();

            while (match.Success)
            {
                string name = match.Groups["Name"].Value;
                classNames.Add(name);
                match = match.NextMatch();
            }

            return classNames;
        }
		
		#endregion [rgn]

    }
}
