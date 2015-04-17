using MailProcessor.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailProcessor
{
    class CCommandFinder : ICommandFinder
    {
        #region IActionFinder Members

        public ICommand GetCommand(string strMessageId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
