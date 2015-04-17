using MailProcessor.Lib.Exchange;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            ExchangeService service = ExchangeConnector.Connect("mail@c2dev.onmicrosoft.com", "password18#");
        }
    }
}
