using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MailProcessor.Lib;
using MailProcessor;
using System.Linq;

namespace Tests.MailProcessor.UnitTests
{
    [TestClass]
    public class CTestCommandExecutor
    {
        [TestMethod]
        public void CommandExecutor_ShouldDeleteMessage()
        {
            CFakeMessage message = new CFakeMessage("1", "Subject 1", "Body 1");
            CFakeMessageSource messageSource = new CFakeMessageSource(new IMessage[] { message });

            ICommandExecutor CommandExecutor = new CCommandExecutor(messageSource);
            CommandExecutor.Execute(new CCommandDelete(), message);

            Assert.IsTrue(message.IsDeleted, "Message was not deleted");
        }

        [TestMethod]
        public void CommandExecutor_ShouldSkipMessage()
        {
            string strExpectedSubject = "Subject 1";
            string strExpectedBody = "Body 1";

            CFakeMessage message = new CFakeMessage("1", strExpectedSubject, strExpectedBody);
            IMessageSource messageSource = new CFakeMessageSource(new IMessage[] { message });

            ICommandExecutor CommandExecutor = new CCommandExecutor(messageSource);
            CommandExecutor.Execute(new CCommandSkip(), message);

            Assert.AreEqual<string>(strExpectedSubject, message.Subject, "Subject was modified");
            Assert.AreEqual<string>(strExpectedBody, message.Body, "Body was modified");
        }

        [TestMethod]
        public void CommandExecutor_ShouldMarkMessageAsSpam()
        {
            string strSubject = "Subject 1";
            string strExptectedSubject = String.Format("[SPAM] {0}", strSubject);

            CFakeMessage message = new CFakeMessage("1", strSubject, "Body BUY OUR CHEAP PRODUCT");
            CFakeMessageSource messageSource = new CFakeMessageSource(new IMessage[] { message });

            ICommandExecutor CommandExecutor = new CCommandExecutor(messageSource);
            CommandExecutor.Execute(new CCommandMarkAsSpam(), message);

            Assert.AreEqual<string>(strExptectedSubject, message.Subject, "Message subject was not marked with [SPAM] prefix");
            Assert.IsTrue(message.IsUpdated, "Message was not updated");
        }
    }
}
