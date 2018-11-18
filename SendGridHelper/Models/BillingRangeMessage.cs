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

        private string _emailToRedirect;

        public string EmailToRedirect {
            get { return _emailToRedirect; }
            set {
                _emailToRedirect = value;
                OnPropertyChanged("EmailToRedirect");
            }
        }

        private string _subject;

        public string Subject {
            get { return _subject; }
            set {
                _subject = value;
                OnPropertyChanged("Subject");
            }
        }

        private string _signature;

        public string Signature {
            get { return _signature; }
            set {
                _signature = value;
                OnPropertyChanged("Signature");
            }
        }

        private string _message;

        public string Message {
            get { return _message; }
            set { _message = value;
                OnPropertyChanged("Message");
            }
        }


        public virtual Company Campaign { get; set; }
    }
}
