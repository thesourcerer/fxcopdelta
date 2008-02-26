using System;
using System.Collections.Generic;
using System.Text;

namespace CustomPolicies.CheckinAnalysis
{
    /// <summary>
    /// Retrieves names of a specific element type (e.g. class, struct, namespace etc.) from C# code.
    /// </summary>
    public interface IElementNameReader
    {
        /// <summary>
        /// Retrieve names of all instances of the element type from the specified code block.
        /// </summary>
        /// <param name="code">The code to retrieve names from.</param>
        /// <returns>A list of names of all instances of the element.</returns>
        IList<string> RetrieveNames(string code);
    }
}
