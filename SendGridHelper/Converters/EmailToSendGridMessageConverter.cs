using SendGrid.Helpers.Mail;
using SendGridHelper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SendGridHelper.Converters {
    public static class EmailToSendGridMessageConverter {
        public static SendGridMessage ToSendGridMessageToMultipleRecipients(this Email email) {
            return MailHelper.CreateSingleEmailToMultipleRecipients(email.From.ToEmailAdress(),
                                                                       email.To.ToListEmailAdress(),
                                                                       email.Subject,
                                                                       email.PlainTextContent,
                                                                       email.HtmlContent,
                                                                       email.ShowAllRecipients);
        }

        public static SendGridMessage ToSendGridMessageToSingleRecipient(this Email email) {
            return MailHelper.CreateSingleEmail(email.From.ToEmailAdress(),
                                                    email.To[0].ToEmailAdress(),
                                                    email.Subject,
                                                    email.PlainTextContent,
                                                    email.HtmlContent);
        }
    }
}
