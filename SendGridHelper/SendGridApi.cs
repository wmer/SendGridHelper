using SendGrid;
using SendGridHelper.Converters;
using SendGridHelper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SendGridHelper {
    public class SendGridApi {
        private string _apiKey;

        public SendGridApi(string apiKey) {
            _apiKey = apiKey;
        }

        public Task<Response> SendSingleEmail(Email email) {
            var client = new SendGridClient(_apiKey);
            var msg = email.ToSendGridMessageToSingleRecipient();
            //msg.SetSpamCheck(true);
            //msg.SetClickTracking(true, false);
            //msg.SetOpenTracking(true);
            return client.SendEmailAsync(msg);
        }

        public Task<Response> SendToMultipleRecipients(Email email) {
            var client = new SendGridClient(_apiKey);
            var msg = email.ToSendGridMessageToMultipleRecipients();
            //msg.SetSpamCheck(true);
            //msg.SetClickTracking(true, false);
            //msg.SetOpenTracking(true);
            return client.SendEmailAsync(msg);
        }
    }
}
