using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckinAnalyzer;
using Rhino.Mocks;
using System.IO;

namespace TypeAnalyzer.Tests
{
    /// <summary>
    /// Tests the <see cref="TypeLocator"/> class.
    /// </summary>
    [TestClass]
    public class TypeLocatorTests
    {
        private MockRepository _mockRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new MockRepository();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mockRepository.VerifyAll();
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

        private IElementNameReader CreateElementNameReaderMock(string code, IList<string> returnedNames)
        {
            IElementNameReader mockedNamespaceReader = _mockRepository.CreateMock<IElementNameReader>();
            Expect
                .On(mockedNamespaceReader)
                .Call(mockedNamespaceReader.RetrieveNames(code))
                .Return(returnedNames);
            return mockedNamespaceReader;
        }


        [TestMethod]
        public void DoesNotLocateTypesInEmptyFile()
        {
            string code = string.Empty;

            // Mock a IElementNameReader that will act as the namespace reader.
            IElementNameReader mockedNamespaceReader = CreateElementNameReaderMock(code, new string[] { string.Empty });

            // Mock a IElementNameReader that will provide names for the TypeLocator.
            // We do not use the CreateElementNameReaderMock since no expectations are neccesary.
            IElementNameReader mockedElementNameReader = _mockRepository.CreateMock<IElementNameReader>();

            TypeLocator typeLocator = new TypeLocator(mockedNamespaceReader, new IElementNameReader[]{ mockedElementNameReader });

            string path = WriteTemporaryFile(code);

            IList<string> typeNames = typeLocator.GetTypeNames(path);
            Assert.AreEqual(0, typeNames.Count);
        }

        //Test: no namespace returns empty list.

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

        private string WriteTemporaryFile(string code)
        {
            string temporaryFilePath = Path.GetTempFileName();
            File.WriteAllText(temporaryFilePath, code);
            return temporaryFilePath;
        }
    }
}
