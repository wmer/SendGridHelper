using ADO.ORM.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SendGridHelper.Models {
    public class Email {
        [PrimaryKey]
        public int Id { get; set; }
        public virtual Contact From { get; set; }
        public virtual List<Contact> To { get; set; }
        public string Subject { get; set; }
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; } = "";
        public bool ShowAllRecipients { get; set; }
        public virtual Campaign Campaign { get; set; }
    }
}