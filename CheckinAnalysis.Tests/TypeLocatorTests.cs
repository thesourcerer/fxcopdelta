using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomPolicies.CheckinAnalysis;
using Rhino.Mocks;
using System.IO;

namespace CustomPolicies.CheckinAnalysis.Tests
{
    /// <summary>
    /// Tests the <see cref="TypeLocator"/> class.
    /// </summary>
    [TestClass]
    public class TypeLocatorTests
    {
		
		#region [rgn] Fields (1)

		private MockRepository _mockRepository;

		#endregion [rgn]

		#region [rgn] Constructors (1)

		[TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ThrowsOnMultipleNamespaces()
        {
            string code = "Namespace MyNamespace1 { public class MyClass1 {} } Namespace MyNamespace2 { public class MyClass2 {} }";

            // Mock a IElementNameReader that will act as the namespace reader.
            IElementNameReader mockedNamespaceReader = CreateElementNameReaderMock(code, new string[] { "MyNamespace1", "MyNamespace2" });

            // Mock a IElementNameReader that will provide names for the TypeLocator.
            // We do not use the CreateElementNameReaderMock since no expectations are neccesary.
            IElementNameReader mockedElementNameReader = _mockRepository.CreateMock<IElementNameReader>();

            _mockRepository.ReplayAll();

            TypeLocator typeLocator = new TypeLocator(mockedNamespaceReader, new IElementNameReader[] { mockedElementNameReader });
            string path = WriteTemporaryFile(code);

            IList<string> typeNames = typeLocator.GetTypeNames(path);
        }
		
		#endregion [rgn]

		#region [rgn] Methods (8)

		// [rgn] Public Methods (6)

		[TestCleanup]
        public void Cleanup()
        {
            _mockRepository.VerifyAll();
        }
		
		[TestMethod]
        public void DoesNotLocateTypesInEmptyFile()
        {
            string code = string.Empty;

            // Mock a IElementNameReader that will act as the namespace reader.
            IElementNameReader mockedNamespaceReader = CreateElementNameReaderMock(code, new string[] { });

            // Mock a IElementNameReader that will provide names for the TypeLocator.
            // We do not use the CreateElementNameReaderMock since no expectations are neccesary.
            IElementNameReader mockedElementNameReader = _mockRepository.CreateMock<IElementNameReader>();

            _mockRepository.ReplayAll();

            TypeLocator typeLocator = new TypeLocator(mockedNamespaceReader, new IElementNameReader[] { mockedElementNameReader });

            string path = WriteTemporaryFile(code);

            IList<string> typeNames = typeLocator.GetTypeNames(path);
            Assert.AreEqual(0, typeNames.Count);
        }
		
		[TestMethod]
        public void DoesNotLocateTypesWithoutNamespace()
        {
            string code = "using System;";

            // Mock a IElementNameReader that will act as the namespace reader.
            IElementNameReader mockedNamespaceReader = CreateElementNameReaderMock(code, new string[] { });

            // Mock a IElementNameReader that will provide names for the TypeLocator.
            // We do not use the CreateElementNameReaderMock since no expectations are neccesary.
            IElementNameReader mockedElementNameReader = _mockRepository.CreateMock<IElementNameReader>();

            _mockRepository.ReplayAll();

            TypeLocator typeLocator = new TypeLocator(mockedNamespaceReader, new IElementNameReader[] { mockedElementNameReader });

            string path = WriteTemporaryFile(code);

            IList<string> typeNames = typeLocator.GetTypeNames(path);
            Assert.AreEqual(0, typeNames.Count);
        }
		
		[TestMethod]
        public void FindsMultipleType()
        {
            string code = "Namespace MyNamespace { public class MyClass {} public class MyStruct {} }";

            // Mock a IElementNameReader that will act as the namespace reader.
            IElementNameReader mockedNamespaceReader = CreateElementNameReaderMock(code, new string[] { "MyNamespace" });

            // Mock two IElementNameReaders that will provide names for the TypeLocator.
            IElementNameReader mockedElementNameReader1 = CreateElementNameReaderMock(code, new string[] { "MyClass" });
            IElementNameReader mockedElementNameReader2 = CreateElementNameReaderMock(code, new string[] { "MyStruct" });

            _mockRepository.ReplayAll();

            TypeLocator typeLocator = new TypeLocator(mockedNamespaceReader, new IElementNameReader[] { mockedElementNameReader1, mockedElementNameReader2 });
            string path = WriteTemporaryFile(code);

            IList<string> typeNames = typeLocator.GetTypeNames(path);

            Assert.AreEqual(2, typeNames.Count);
            Assert.AreEqual("MyNamespace.MyClass", typeNames[0]);
            Assert.AreEqual("MyNamespace.MyStruct", typeNames[1]);
        }
		
		[TestMethod]
        public void FindsSingleType()
        {
            string code = "Namespace MyNamespace { public class MyClass {} }";

            // Mock a IElementNameReader that will act as the namespace reader.
            IElementNameReader mockedNamespaceReader = CreateElementNameReaderMock(code, new string[] { "MyNamespace" });

            // Mock a IElementNameReader that will provide names for the TypeLocator.
            IElementNameReader mockedElementNameReader = CreateElementNameReaderMock(code, new string[] { "MyClass" });

            _mockRepository.ReplayAll();

            TypeLocator typeLocator = new TypeLocator(mockedNamespaceReader, new IElementNameReader[] { mockedElementNameReader });
            string path = WriteTemporaryFile(code);

            IList<string> typeNames = typeLocator.GetTypeNames(path);

            Assert.AreEqual(1, typeNames.Count);
            Assert.AreEqual("MyNamespace.MyClass", typeNames[0]);
        }
		
		[TestInitialize]
        public void Initialize()
        {
            _mockRepository = new MockRepository();
        }
		
		// [rgn] Private Methods (2)

		private IElementNameReader CreateElementNameReaderMock(string willAccept, IList<string> willReturn)
        {
            IElementNameReader mockedNamespaceReader = _mockRepository.CreateMock<IElementNameReader>();
            Expect
                .On(mockedNamespaceReader)
                .Call(mockedNamespaceReader.RetrieveNames(willAccept))
                .Return(willReturn);
            return mockedNamespaceReader;
        }
		
		private string WriteTemporaryFile(string code)
        {
            string temporaryFilePath = Path.GetTempFileName();
            File.WriteAllText(temporaryFilePath, code);
            return temporaryFilePath;
        }
		
		#endregion [rgn]

    }
}
