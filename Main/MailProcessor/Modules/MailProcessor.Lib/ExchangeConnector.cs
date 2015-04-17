using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MailProcessor.Lib.Exchange
{
    public class ExchangeConnector
    {
        /// <summary>
        /// Create an EWS object connected to specific mailbox
        /// </summary>
        /// <remarks>
        /// Usage:
        /// ExchangeService service = ExchangeConnection.Connect("mail@c2dev.onmicrosoft.com", "password18#");
        /// </remarks>
        /// <param name="strEmailAddress">Mailbox user email address</param>
        /// <param name="strPassword">Mailbox user password</param>
        /// <returns>An EWS object connected to specific mailbox</returns>
        public static ExchangeService Connect(String strEmailAddress, String strPassword)
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP2)
            {
                TraceEnabled = false,
                TraceFlags = TraceFlags.None,
                TraceListener = null
            };

            // Specify user credentials
            service.Credentials = new NetworkCredential(strEmailAddress, strPassword);

            // Use Office 365 Autodiscover URL
            service.AutodiscoverUrl(strEmailAddress, RedirectionUrlValidationCallback);
            return service;
        }
        /// <summary>
        /// Redirection callback used in Autodicovery
        /// </summary>
        /// <param name="strRedirectionUrl"></param>
        /// <returns></returns>
        private static bool RedirectionUrlValidationCallback(String strRedirectionUrl)
        {
            Uri url = new Uri(strRedirectionUrl);
            return url.Scheme == "https";
        }
    }
}
