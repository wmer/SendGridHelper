using ADO.ORM.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SendGridHelper.Models {
    public class Contact {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
