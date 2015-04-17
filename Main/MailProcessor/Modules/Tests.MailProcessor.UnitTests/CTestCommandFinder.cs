using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailProcessor;
using MailProcessor.Lib;

namespace Tests.MailProcessor.UnitTests
{
    [TestClass]
    public class CTestCommandFinder
    {
        [TestMethod]
        public void CommandFinder_ShouldReturnSkipAction()
        {
            CFakeMessage message = new CFakeMessage("1", "Normal message", "Normal message body");

            ICommandFinder finder = new CCommandFinder();
            ICommand command = finder.GetCommand(message.EntryId);

            Assert.IsInstanceOfType(command, typeof(CCommandSkip), "Message should be skipped");
        }

        [TestMethod]
        public void CommandFinder_ShouldReturnDeleteAction()
        {
            CFakeMessage message = new CFakeMessage("1", "[DELETEME] Message subject", "Normal message body");

            ICommandFinder finder = new CCommandFinder();
            ICommand command = finder.GetCommand(message.EntryId);

            Assert.IsInstanceOfType(command, typeof(CCommandDelete), "Message should be deleted");
        }

        [TestMethod]
        public void CommandFinder_ShouldReturnMarkMessageAsSpamAction()
        {
            CFakeMessage message = new CFakeMessage("1", "Test message", "Body BUY OUR CHEAP PRODUCT");

            ICommandFinder finder = new CCommandFinder();
            ICommand command = finder.GetCommand(message.EntryId);

            Assert.IsInstanceOfType(command, typeof(CCommandMarkAsSpam), "Message should be marked as spam");
        }
        
    }
}
