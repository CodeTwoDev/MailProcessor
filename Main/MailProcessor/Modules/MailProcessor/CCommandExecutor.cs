using MailProcessor.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailProcessor
{
    internal class CCommandExecutor : ICommandExecutor
    {
        private IMessageSource m_messageSource;

        public CCommandExecutor(IMessageSource messageSource)
        {
            m_messageSource = messageSource;
        }

        #region ICommandExecutor Members

        public void Execute(ICommand command, IMessage message)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
