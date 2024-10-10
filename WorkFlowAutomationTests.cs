using System;
using Xunit;
using WorkflowAutomation;

namespace WorkflowAutomation.Tests
{
    public class WorkFlowAutomationTests
    {
        [Fact]
        public void TestDocumentCreation()
        {
            var doc = new Document("TestDoc", "TestPath", "TestDescription", "TestSubmitter");
            Assert.Equal("TestDoc", doc.Name);
            Assert.Equal("TestPath", doc.Path);
            Assert.Equal("TestDescription", doc.Description);
            Assert.Equal("TestSubmitter", doc.Submitter);
            Assert.Equal(Status.Submitted, doc.DocumentStatus);
        }

        [Fact]
        public void TestProcessDocument_Rejected()
        {
            var doc = new Document("TestDoc", "", "TestDescription", "TestSubmitter");
            WorkFlowEngine.processDocument(doc);
            Assert.Equal(Status.Rejected, doc.DocumentStatus);
        }

        [Fact]
        public void TestProcessDocument_Submitted()
        {
            var doc = new Document("TestDoc", "TestPath", "TestDescription", "TestSubmitter");
            WorkFlowEngine.processDocument(doc);
            Assert.Equal(Status.Submitted, doc.DocumentStatus);
        }
    }
}
