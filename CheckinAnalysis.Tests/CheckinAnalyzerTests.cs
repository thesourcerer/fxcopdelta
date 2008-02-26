using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace CustomPolicies.CheckinAnalysis.Tests
{
    /// <summary>
    /// Tests the <see cref="CheckinAnalyzer"/> class.
    /// </summary>
    [TestClass]
    public class CheckinAnalyzerTests
    {

        // Tests for GetModifiedTypes():
        // calls GetTypeNames for every pending change
        // calls GetTypeNames only when Add
        // calls GetTypeNames only when Edit
        // calls GetTypeNames only when Add | Edit
        // does not call GetTypeNames for files other than .cs
        // returns every item that is returned by GetTypeNames        
    }
}
