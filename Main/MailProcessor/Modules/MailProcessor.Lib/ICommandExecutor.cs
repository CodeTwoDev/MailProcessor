using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailProcessor.Lib
{
    /// <summary>
    /// Wykonywacz komend na wiadomościach
    /// </summary>
    public interface ICommandExecutor
    {
        /// <summary>
        /// Wykonuje akcję na zadanej wiadomości
        /// </summary>
        /// <param name="action">akcja do wykonania</param>
        /// <param name="message">wiadomość, na której akcja ma zostać wykonana</param>
        /// <param name="source">źródło wiadomości</param>
        void Execute(ICommand command, IMessage message);
    }
}
