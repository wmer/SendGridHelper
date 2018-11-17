using ADO.ORM.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using WPF.Tools.MVVM.ViewModel;

namespace SendGridHelper.Models {
    public class BillingRangeMessage : ViewModelBase {
        [PrimaryKey]
        public int Id { get; set; }
        private int _range;

        public int Range {
            get { return _range; }
            set { _range = value;
                OnPropertyChanged("Range");
            }
        }

        private string _message;

        public string Message {
            get { return _message; }
            set { _message = value;
                OnPropertyChanged("Message");
            }
        }


        public virtual Campaign Campaign { get; set; }
    }
}
