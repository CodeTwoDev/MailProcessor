using MailProcessor.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.MailProcessor.UnitTests
{
    class CFakeCommandExecutor : ICommandExecutor
    {
        public Dictionary<IMessage, ICommand> ExecutedActions;

        public CFakeCommandExecutor()
        {
            this.ExecutedActions = new Dictionary<IMessage, ICommand>();
        }

        #region ICommandExecutor Members

        public void Execute(ICommand command, IMessage message)
        {
            this.ExecutedActions.Add(message, command);
        }

        #endregion
    }
}
