using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailProcessor.Lib
{
    /// <summary>
    /// Główny procesor wiadomości. Odpowiada za przetworzenie wiadomosci pobranych ze źródła wiadomości
    /// </summary>
    public class CMessagesProcessor
    {
        private IMessageSource m_messageSource;
        private ICommandFinder m_actionFinder;
        private ICommandExecutor m_actionExecutor;

        /// <summary>
        /// Tworzy nową instancję <see cref="CMessagesProcessor"/>
        /// </summary>
        /// <param name="messageSource">źródło wiadomości</param>
        /// <param name="actionFinder">wyszukiwacz akcji</param>
        /// <param name="actionExecutor">wykonywacz akcji</param>
        public CMessagesProcessor(IMessageSource messageSource, ICommandFinder actionFinder, ICommandExecutor actionExecutor)
        {
            m_messageSource = messageSource;
            m_actionFinder = actionFinder;
            m_actionExecutor = actionExecutor;
        }

        /// <summary>
        /// Procesuje wiadomości znajdujące się w źródle. Sprawdza jakie akcje należy wykonać na wiadomościach
        /// i wykonuje je przy użyciu zadanego wykonywacza
        /// </summary>
        public void Proceed()
        {
            foreach (IMessage message in m_messageSource.GetAll())
            {
                ICommand command = m_actionFinder.GetCommand(message.EntryId);
                m_actionExecutor.Execute(command, message);
            }
        }
    }
}
