using MailProcessor.Lib;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Tests.MailProcessor.UnitTests
{
    class CFakeMessage : IMessage
    {
        public CFakeMessage(string strEntryId, string strSubject, string strBody)
        {
            this.EntryId = strEntryId;
            this.Subject = strSubject;
            this.Body = strBody;
        }
        #region IMessage Members

        public string EntryId
        {
            get;
            private set;
        }

        public string Subject
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        internal bool IsDeleted
        {
            get;
            private set;
        }

        internal bool IsUpdated
        {
            get;
            private set;
        }

        public void Update()
        {
            this.IsUpdated = true;
        }

        public void Delete()
        {
            this.IsDeleted = true;
        }

        #endregion

    }
}
