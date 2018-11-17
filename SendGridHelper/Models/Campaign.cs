using ADO.ORM.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using WPF.Tools.MVVM.ViewModel;

namespace SendGridHelper.Models {
    public class Campaign : ViewModelBase {
        [PrimaryKey]
        public int Id { get; set; }

        
        private string _company;

        public string Company {
            get { return _company; }
            set { _company = value;
                OnPropertyChanged("Company");
            }
        }

        private string _emailToRedirect;

        public string EmailToRedirect {
            get { return _emailToRedirect; }
            set { _emailToRedirect = value;
                OnPropertyChanged("EmailToRedirect");
            }
        }

        private string _subject;

        public string Subject {
            get { return _subject; }
            set { _subject = value;
                OnPropertyChanged("Subject");
            }
        }

        private string _signature;

        public string Signature {
            get { return _signature; }
            set { _signature = value;
                OnPropertyChanged("Signature");
            }
        }


        public DateTime Date { get; set; }
        public virtual List<BillingRangeMessage> BillingRangeMessages { get; set; }
    }
}
