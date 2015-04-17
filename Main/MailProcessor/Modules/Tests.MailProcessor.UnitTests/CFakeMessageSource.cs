using MailProcessor.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.MailProcessor.UnitTests
{
    class CFakeMessageSource : IMessageSource
    {
        private List<IMessage> m_messages;

        public CFakeMessageSource(IEnumerable<IMessage> messages)
        {
            m_messages = new List<IMessage>(messages);
        }

        #region IMessageSource Members

        public IMessage Find(string strMessageId)
        {
            return m_messages.FirstOrDefault(message => message.EntryId == strMessageId);
        }

        public IEnumerable<IMessage> GetAll()
        {
            return m_messages;
        }

        #endregion
    }
}
