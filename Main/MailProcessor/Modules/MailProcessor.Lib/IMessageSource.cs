using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailProcessor.Lib
{
    /// <summary>
    /// Źródło wiadomości. Udostępnia interfejs do pobierania wiadomości oraz operowania na nich
    /// </summary>
    public interface IMessageSource
    {
        /// <summary>
        /// Zwraca wiadomość dla zadanego <paramref name="strMessageId"/>
        /// </summary>
        /// <param name="strMessageId">identyfikator wiadomości</param>
        /// <returns></returns>
        IMessage Find(string strMessageId);

        /// <summary>
        /// Zwraca wszystkie wiadomości
        /// </summary>
        /// <returns>kolekcja wiadomości</returns>
        IEnumerable<IMessage> GetAll();
    }
}
