using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomPolicies.CheckinAnalysis
{
    /// <summary>
    /// Reads names of namespaces found in a C# code block.
    /// </summary>
    public class NamespaceNameReader : IElementNameReader
    {
		
		#region [rgn] Fields (1)

		private const string NamespacePattern = @"namespace\s+(?<Name>.+?)\s*\{(?<Body>[^\{\}]*(?:(?:(?<Open>\{)[^\{\}]*)+(?:(?<Close-Open>\})[^\{\}]*)+)*(?(Open)(?!)))\}";

		#endregion [rgn]

		#region [rgn] Methods (2)

		// [rgn] Public Methods (1)

		/// <summary>
        /// Retrieve names of all namespace instances from the specified code block.
        /// </summary>
        /// <param name="code">The code to retrieve names from.</param>
        /// <returns>A list of namespace names found in the code block.</returns>
        public IList<string> RetrieveNames(string code)
        {
            IList<string> namespaceNames = new List<string>();

            foreach(string name in GetNames(code))
            {
                namespaceNames.Add( name );
            }

            return namespaceNames;
        }
		
		// [rgn] Private Methods (1)

		/// <summary>
        /// Parses code and retrieves namespace names from it.
        /// </summary>
        /// <remarks>
        /// Automatically performs nesting of namespace names. e.g:
        ///
        /// namespace My
        /// {
        ///     namespace Special
        ///     {
        ///         namespace Namespace
        ///         {
        ///             ...
        ///         }
        ///     }
        /// }
        /// 
        /// Will turn into "My.Special.Namespace".
        /// </remarks>
        private IEnumerable<string> GetNames(string code)
        {
            Regex regex = new Regex(NamespacePattern);
            Match match = regex.Match(code);

            while (match.Success)
            {
                string name = match.Groups["Name"].Value;
                string body = match.Groups["Body"].Value;

                bool hasNestedNamespaces = GetNames(body).GetEnumerator().MoveNext();
                if (!hasNestedNamespaces)
                {
                    yield return name;
                }
                else
                {
                    // Search for any nested namespaces inside this namespace's body and if 
                    // found, concatenate them into a single namespace
                    foreach (string nestedName in GetNames(body))
                    {
                        string completeName = string.Format("{0}.{1}", name, nestedName);
                        yield return completeName;
                    }
                }

                match = match.NextMatch();
            }
        }
		
		#endregion [rgn]

    }
}
