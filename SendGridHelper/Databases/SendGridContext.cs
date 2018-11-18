using ADO.ORM.Core;
using ADO.ORM.Core.Attributes;
using ADO.ORM.SQLite.Core;
using SendGridHelper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SendGridHelper.Databases {
    public class SendGridContext : SqLiteContext {
        [Ignore]
        public static string DatabaseLocation { get; set; } = $"{AppDomain.CurrentDomain.BaseDirectory}\\Databases";

        public SendGridContext() : base(DatabaseLocation, "SendGrid") {
        }

        public Repository<Company> Campaign { get; set; }
        public Repository<Contact> Contact { get; set; }
        public Repository<Email> Email { get; set; }
        public Repository<BillingRangeMessage> BillingRangeMessage { get; set; }
    }
}
