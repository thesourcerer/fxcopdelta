using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace CustomPolicies.CheckinAnalysis
{
    /// <summary>
    /// Locates type names which are defined in C# code files.
    /// </summary>
    public class TypeLocator : ITypeLocator
    {
		
		#region [rgn] Fields (3)

		private readonly IList<IElementNameReader> _elementNameReaders;
		private readonly IElementNameReader _namespaceReader;
		private const string MultipleNamespaceNotSupport = "Multiple namespaces in a single code file are not supported. Change file \"{0}\" so it will contain one namespace or report to omer@rauchy.net to get this fixed.";

		#endregion [rgn]

		#region [rgn] Constructors (2)

		/// <summary>
        /// Initializes a new instance of the <see cref="TypeLocator"/> class 
        /// with a specific set of <see cref="IElementNameReader"/>.
        /// </summary>
        /// <param name="namespaceReader">The element reader which will be 
        /// used to identify namespaces inside the code.</param>
        /// <param name="elementNameReaders">A list of objects which will be used 
        /// to retrieve types from the code files.</param>
        public TypeLocator(IElementNameReader namespaceReader, IList<IElementNameReader> elementNameReaders)
        {
            _namespaceReader = namespaceReader;
            _elementNameReaders = elementNameReaders;
        }
		
		/// <summary>
        /// Initializes a new instance of the <see cref="TypeLocator"/> class 
        /// with a default <see cref="NamespaceReader"/> and 
        /// set of <see cref="IElementNameReader"/> implementations.
        /// </summary>
        public TypeLocator()
        {
            _namespaceReader = new NamespaceNameReader();

            _elementNameReaders = new List<IElementNameReader>();
            _elementNameReaders.Add(new ClassNameReader());
        }
		
		#endregion [rgn]

		#region [rgn] Methods (1)

		// [rgn] Public Methods (1)

		/// <summary>
        /// Locates types in a C# code file.
        /// </summary>
        /// <param name="path">The path of the C# code file to locate types in.</param>
        /// <returns>The names of any classes, structs, interfaces, enums or delegates.</returns>
        /// <exception cref="NotImplementedException">
        /// Thrown when the provided code contains more than 1 namespace.
        /// There is no actual reason for this, it is just not implemented yet.
        /// </exception>
        public IList<string> GetTypeNames(string path)
        {
            string code = File.ReadAllText(path);

            // Get the namespaces found in this code.
            IList<string> namespaces = _namespaceReader.RetrieveNames(code);

            if (namespaces.Count > 1)
            {
                // Currently only zero or one namespaces are supported inside every code file.
                string formattedMessage = string.Format(MultipleNamespaceNotSupport, path);
                throw new NotImplementedException(formattedMessage);
            }
            else if ( namespaces.Count == 0 )
            {
                return new List<string>();
            }
            else
            {
                // Only one namespace has been found.
                string namespaceName = namespaces[0];

                IList<string> completeTypeNames = new List<string>();
                // Read all type names from all the initialized IElementNameReader implementations.
                foreach( IElementNameReader elementNameReader in _elementNameReaders )
                {
                    // Get all type names found by this IElementNameReader.
                    IList<string> typeNames = elementNameReader.RetrieveNames(code);
                    foreach(string typeName in typeNames)
                    {
                        // Combine the namespace and type name to create a full type name.
                        string fullTypeName = string.Format("{0}.{1}", namespaceName, typeName);
                        completeTypeNames.Add(fullTypeName);
                    }
                }

                return completeTypeNames;
            }

        }
		
		#endregion [rgn]

    }
}
