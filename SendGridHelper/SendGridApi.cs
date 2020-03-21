using SendGrid;
using SendGridHelper.Converters;
using SendGridHelper.Helpers;
using SendGridHelper.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SendGridHelper {
    public class SendGridApi {
        private string _apiKey;
        private SendGridClient _client;
        private ConsumingApiHelper _consumingApiHelper;

        public SendGridApi(string apiKey) {
            _apiKey = apiKey;
            _client = new SendGridClient(_apiKey);
            _consumingApiHelper = new ConsumingApiHelper(apiKey);
        }

        public async Task<Response> SendSingleEmail(Email email, params string[] files) {
            var msg = email.ToSendGridMessageToSingleRecipient();
            if (files != null) {
                foreach(var file in files) {
                    if(!string.IsNullOrEmpty(file)) {
                        var fileInfo = new FileInfo(file);
                        using(var fileStream = File.OpenRead(file)) {
                            await msg.AddAttachmentAsync(fileInfo.Name, fileStream);
                        }
                    }
                }

            }
            return await _client.SendEmailAsync(msg);
        }

        public async Task<Response> SendToMultipleRecipients(Email email, params string[] files) {
            var msg = email.ToSendGridMessageToMultipleRecipients();
            if (files != null) {
                foreach(var file in files) {
                    if(!string.IsNullOrEmpty(file)) {
                        var fileInfo = new FileInfo(file);
                        using(var fileStream = File.OpenRead(file)) {
                            await msg.AddAttachmentAsync(fileInfo.Name, fileStream);
                        }
                    }
                }
                return await _client.SendEmailAsync(msg);
            }
            return await _client.SendEmailAsync(msg);
        }

        public async Task<List<Stats>> GetStats(string startDate, string endDate = null, AggregatedBy aggregatedBy = null, ByType byType = null) {
            var endpoint = $"/stats?start_date={startDate}";
            if (!string.IsNullOrEmpty(endDate)) {
                endpoint = $"{endpoint}&end_date={endDate}";
            }
            if (aggregatedBy != null) {
                endpoint = $"/stats?aggregated_by={aggregatedBy.Value}&start_date={startDate}";
            }
            if (aggregatedBy != null && !string.IsNullOrEmpty(endDate)) {
                endpoint = $"/stats?aggregated_by={aggregatedBy.Value}&start_date={startDate}&end_date={endDate}";
            }

            if (byType != null) {
                endpoint = $"/{byType.Value}{endpoint}";
            }

            var (result, statusCode, message) = await _consumingApiHelper.GetAssync<List<Stats>>(endpoint);
            return result;
        }

        public async Task<EmailActivity> GetEmailActivity(QueryActivity query = null, int limit = 1000) {
            var endpoint = $"/messages?limit={limit}";
            if (query != null) {
                endpoint = $"/messages?query={query.Value}&limit={limit}";
            }
            var (result, statusCode, message) = await _consumingApiHelper.GetAssync<EmailActivity>(endpoint);
            return result;
        }

    }
}
