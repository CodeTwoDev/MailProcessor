using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailProcessor.Lib
{
    /// <summary>
    /// Odpowiada za zwracanie komendy dla zadanej wiadomości
    /// </summary>
    public interface ICommandFinder
    {
        /// <summary>
        /// Zwraca komendę dla zadanej wiadomości
        /// </summary>
        /// <param name="message">wiadomość</param>
        /// <returns>komenda, która ma zostać wykonana na wiadomości</returns>
        ICommand GetCommand(string strMessageId);
    }
}
