using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomPolicies.CheckinAnalysis;

namespace CustomPolicies.CheckinAnalysis.Tests
{
    /// <summary>
    /// Tests the <see cref="ClassNameReader"/> class.
    /// </summary>
    [TestClass]
    public class ClassNameReaderTests
    {
		
		#region [rgn] Fields (1)

		private IElementNameReader _classNameReader;

		#endregion [rgn]

		#region [rgn] Methods (6)

		// [rgn] Public Methods (6)

		[TestMethod]
        public void DoesNotFindClassesInEmptyString()
        {
            string code = string.Empty;
            IList<string> names = _classNameReader.RetrieveNames(code);
            Assert.AreEqual(0, names.Count);
        }
		
		[TestMethod]
        public void FindsMultipleClassesInsideSingleNamespace()
        {
            string code = "namespace MyNamespace { public class Class1 {} public class Class2 {} }";
            IList<string> names = _classNameReader.RetrieveNames(code);
            Assert.AreEqual(2, names.Count);
            Assert.AreEqual("Class1", names[0]);
            Assert.AreEqual("Class2", names[1]);
        }

        [TestMethod]
        public void FindsClassWithoutTypeVisibility()
        {
            string code = "class Class1 {}";
            IList<string> names = _classNameReader.RetrieveNames(code);
            Assert.AreEqual(1, names.Count);
            Assert.AreEqual("Class1", names[0]);
        }
		
		[TestMethod]
        public void FindsMultipleStandaloneClasses()
        {
            string code = "public class Class1 {} public class Class2 {}";
            IList<string> names = _classNameReader.RetrieveNames(code);
            Assert.AreEqual(2, names.Count);
            Assert.AreEqual("Class1", names[0]);
            Assert.AreEqual("Class2", names[1]);
        }
		
		[TestMethod]
        public void FindsSingleClassInsideNamespace()
        {
            string code = "namespace MyNamespace { public class MyClass {} }";
            IList<string> names = _classNameReader.RetrieveNames(code);
            Assert.AreEqual(1, names.Count);
            Assert.AreEqual("MyClass", names[0]);
        }
		
		[TestMethod]
        public void FindsSingleStandaloneClass()
        {
            string code = "public class MyClass {}";
            IList<string> names = _classNameReader.RetrieveNames(code);
            Assert.AreEqual(1, names.Count);
            Assert.AreEqual("MyClass", names[0]);
        }
		
		[TestInitialize]
        public void Initialize()
        {
            _classNameReader = new ClassNameReader();
        }
		
		#endregion [rgn]

    }
}
