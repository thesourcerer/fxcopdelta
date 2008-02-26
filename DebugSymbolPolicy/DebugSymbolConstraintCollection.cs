using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace CustomPolicies.DebugSymbolsPolicy
{
    public class DebugSymbolConstraintCollection : List<DebugSymbolConstraint>
    {
		
		#region [rgn] Fields (1)

		private const string ConstraintsFileName = "DebugSymbolConstraints.xml";

		#endregion [rgn]

		#region [rgn] Methods (3)

		// [rgn] Public Methods (2)

		public static DebugSymbolConstraintCollection Load()
        {
            string constraintsFilePath = GetConstraintsFilePath();

            // Deserialize the constraints file into a ConstraintsCollection.
            XmlSerializer serializer = new XmlSerializer(typeof(DebugSymbolConstraintCollection));
            using (Stream stream = File.OpenRead(constraintsFilePath))
            {
                return (DebugSymbolConstraintCollection)serializer.Deserialize(stream);
            }
        }
		
		public void Save()
        {
            string constraintsFilePath = GetConstraintsFilePath();

            XmlSerializer serializer = new XmlSerializer(typeof(DebugSymbolConstraintCollection));
            using (Stream stream = File.Create(constraintsFilePath))
            {
                serializer.Serialize(stream, this);
            }
        }
		
		// [rgn] Private Methods (1)

		private static string GetConstraintsFilePath()
        {
            // Get the exact location of the constraints file.
            string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string constraintsFilePath = Path.Combine(assemblyDirectory, ConstraintsFileName);
            return constraintsFilePath;
        }
		
		#endregion [rgn]

    }
}
