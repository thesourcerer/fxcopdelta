using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomPolicies.CheckinAnalysis;

namespace CustomPolicies.CheckinAnalysis.Tests
{
    /// <summary>
    /// Tests the <see cref="NamespaceReader"/> class.
    /// </summary>
    [TestClass]
    public class NamespaceNameReaderTests
    {
		
		#region [rgn] Fields (1)

		private IElementNameReader _namespaceNameReader;

		#endregion [rgn]

		#region [rgn] Methods (6)

		// [rgn] Public Methods (6)

		[TestMethod]
        public void DoesNotFindNamespacesInEmptyString()
        {
            string code = string.Empty;
            IList<string> names = _namespaceNameReader.RetrieveNames(code);
            Assert.AreEqual(0, names.Count);
        }
		
		[TestMethod]
        public void FindsMultipleNestedNamespaces()
        {
            string code = "namespace My { namespace Special { namespace Namespace { ... } } namespace Normal { namespace Namespace { ... } } }";
            IList<string> names = _namespaceNameReader.RetrieveNames(code);
            Assert.AreEqual(2, names.Count);
            Assert.AreEqual("My.Special.Namespace", names[0]);
            Assert.AreEqual("My.Normal.Namespace", names[1]);
        }
		
		[TestMethod]
        public void FindsMultipleStandaloneNamespaces()
        {
            string code = "namespace My.Namespace1 {} namespace My.Namespace2 {}";
            IList<string> names = _namespaceNameReader.RetrieveNames(code);
            Assert.AreEqual(2, names.Count);
            Assert.AreEqual("My.Namespace1", names[0]);
            Assert.AreEqual("My.Namespace2", names[1]);
        }
		
		[TestMethod]
        public void FindsSingleNestedNamespace()
        {
            string code = "namespace My { namespace Special { namespace Namespace { ... } } }";
            IList<string> names = _namespaceNameReader.RetrieveNames(code);
            Assert.AreEqual(1, names.Count);
            Assert.AreEqual("My.Special.Namespace", names[0]);
        }
		
		[TestMethod]
        public void FindsSingleStandaloneNamespace()
        {
            string code = "namespace My.Namespace {}";
            IList<string> names = _namespaceNameReader.RetrieveNames(code);
            Assert.AreEqual(1, names.Count);
            Assert.AreEqual("My.Namespace", names[0]);
        }
		
		[TestInitialize]
        public void Initialize()
        {
            _namespaceNameReader = new NamespaceNameReader();
        }
		
		#endregion [rgn]

    }
}
