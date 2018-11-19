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
            set {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private List<BillingRangeMessage> _billingRangeMessages;

        public virtual List<BillingRangeMessage> BillingRangeMessages {
            get { return _billingRangeMessages; }
            set {
                _billingRangeMessages = value;
                OnPropertyChanged("BillingRangeMessages");
            }
        }


        public DateTime Date { get; set; }
    }
}
