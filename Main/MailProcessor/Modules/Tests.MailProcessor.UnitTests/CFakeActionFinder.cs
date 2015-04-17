using MailProcessor.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.MailProcessor.UnitTests
{
    class CFakeCommandFinder : ICommandFinder
    {
        private Func<string, ICommand> m_funcGetCommand;

        public CFakeCommandFinder(Func<string, ICommand> funcGetCommand)
        {
            m_funcGetCommand = funcGetCommand;
        }

        #region ICommandFinder Members

        public ICommand GetCommand(string strMessageId)
        {
            return m_funcGetCommand(strMessageId);
        }

        #endregion
    }
}
