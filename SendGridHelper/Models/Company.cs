using ADO.ORM.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using WPF.Tools.MVVM.ViewModel;

namespace SendGridHelper.Models {
    public class Company : ViewModelBase {
        [PrimaryKey]
        public int Id { get; set; }
        
        private string _name;

        public string Name {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged("Name");
            }
        }

        public DateTime Date { get; set; }
        public virtual List<BillingRangeMessage> BillingRangeMessages { get; set; }
    }
}
