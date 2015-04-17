using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailProcessor.Lib;
using System.Collections.Generic;
using System.Linq;

namespace Tests.MailProcessor.UnitTests
{
    [TestClass]
    public class CTestMessagesProcessor
    {
        [TestMethod]
        public void MessageProcessor_ShouldExecuteActionsForAllMessages()
        {
            CFakeMessage messageToSkip = new CFakeMessage("1", "Mesage to skip", "Should skip this message");
            CFakeMessage messateToDelete = new CFakeMessage("2", "Message to delete", "Should delete this message");
            CFakeMessage messageToMarkAsSpam = new CFakeMessage("3", "Message to mark as spam", "Should mark message as spam");

            CFakeMessageSource messageSource = new CFakeMessageSource(new IMessage[] { messageToSkip, messateToDelete, messageToMarkAsSpam });

            Dictionary<string, ICommand> expectedActionsToExecute = new Dictionary<string, ICommand>() 
            {
                { messageToSkip.EntryId,        new CCommandSkip() },
                { messateToDelete.EntryId,      new CCommandDelete() },
                { messageToMarkAsSpam.EntryId,  new CCommandMarkAsSpam() }
            };

            ICommandFinder commandFinder = new CFakeCommandFinder(strMessageId =>
            {
                return expectedActionsToExecute[strMessageId];
            });

            CFakeCommandExecutor actionExecutor = new CFakeCommandExecutor();

            CMessagesProcessor processor = new CMessagesProcessor(messageSource, commandFinder, actionExecutor);
            processor.Proceed();

            foreach (KeyValuePair<IMessage, ICommand> resultPair in actionExecutor.ExecutedActions)
            {
                ICommand expectedCommand = expectedActionsToExecute[resultPair.Key.EntryId];

                Assert.IsInstanceOfType(resultPair.Value, expectedCommand.GetType(), "Incorrect command type executed on message");
            }
        }

    }
}
