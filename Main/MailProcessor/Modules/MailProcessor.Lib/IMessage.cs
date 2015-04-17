using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailProcessor.Lib
{
    /// <summary>
    /// Reprezentuje wiadomość
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Identyfikator
        /// </summary>
        string EntryId { get; }
        /// <summary>
        /// Temat
        /// </summary>
        string Subject { get; set; }
        /// <summary>
        /// Treść
        /// </summary>
        string Body { get; set; }

        /// <summary>
        /// Aktualizuje wiadomość
        /// </summary>
        void Update();

        /// <summary>
        /// Usuwa wiadomość
        /// </summary>
        void Delete();
    }
}
