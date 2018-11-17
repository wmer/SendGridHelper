using SendGrid;
using SendGrid.Helpers.Mail;
using SendGridHelper;
using SendGridHelper.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGridHelper.Helpers;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            SendWithName();
        }
        
        private static void SendWithoutName() {
            var apiKey = "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";
            var api = new SendGridApi(apiKey);

            var archive1 = $"{Environment.CurrentDirectory}\\Emils\\e-mail 18 dias_07_11.txt";

            var txt = File.ReadAllText(archive1, Encoding.GetEncoding("iso-8859-1"));
            txt = txt.Replace(",", Environment.NewLine);
            txt = txt.Replace(";", Environment.NewLine);

            File.WriteAllText(archive1, txt);

            var msg1 = $"";

            using (var sr = new StreamReader(archive1, Encoding.GetEncoding("iso-8859-1"))) {
                string contato;
                var contatos = new List<Contact>();
                contatos.Add(new Contact { Name = "Mariana", Email = "mariana@4cconsultoria.com.br" });
                contatos.Add(new Contact { Name = "William", Email = "williamss@outlook.com.br" });
                //contatos.Add(new Contact { Name = "Ninho", Email = "marcelo.ninho@4cconsultoria.com.br" });

                while ((contato = sr.ReadLine()) != null) {
                    contato = contato.Trim();
                    if (!string.IsNullOrEmpty(contato) && contato.IsValidEmail()) {
                        contatos.Add(new Contact { Name = "", Email = contato });
                    }
                }

                var emailsSpliteed = contatos.SplitList(300);

                var i = 1;

                foreach (var splited in emailsSpliteed) {
                    var email = new Email {
                        From = new Contact { Name = "", Email = "" },
                        To = splited,
                        Subject = "",
                        PlainTextContent = "",
                        HtmlContent = msg1
                    };


                    var response = api.SendToMultipleRecipients(email).Result;
                    var statusOde = response.StatusCode;
                    var header = response.Headers;
                    var body = response.Body.ReadAsStringAsync().Result;

                    Console.WriteLine($"Gropo {i}:");
                    Console.WriteLine($"Status code: {statusOde}");
                    Console.WriteLine($"Conteudo: {body}");

                    i++;
                }
            }

            Console.ReadKey();
        }

        private static void SendWithName() {
            var apiKey = "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";
            var api = new SendGridApi(apiKey);

            var archive1 = $"{Environment.CurrentDirectory}\\Emils\\Campanha Teste.txt";

            var msg1 = "Olá {0}<br/> Essa é uma mensagem de teste!";

            using (var sr = new StreamReader(archive1, Encoding.GetEncoding("iso-8859-1"))) {
                string contact;

                while ((contact = sr.ReadLine()) != null) {
                    var contacts = new List<Contact>();
                    contact = contact.Trim();


                    if (!string.IsNullOrEmpty(contact)) {
                        var contactSplited = contact.Split(';');
                        var name = contactSplited[0].Trim();
                        var emailAdress = contactSplited[1].Trim();

                        try {
                            if (contactSplited[1].Trim().IsValidEmail()) {
                                contacts.Add(new Contact { Name = name, Email = emailAdress });

                                var messageFormated = string.Format(msg1, name);

                                var email = new Email {
                                    From = new Contact { Name = "William", Email = "master_william_@hotmail.com" },
                                    To = contacts,
                                    Subject = "Campanha de Teste",
                                    PlainTextContent = "",
                                    HtmlContent = messageFormated
                                };


                                var response = api.SendSingleEmail(email).Result;
                                var statusOde = response.StatusCode;
                                var header = response.Headers;
                                var body = response.Body.ReadAsStringAsync().Result;

                                Console.WriteLine($"Status code: {statusOde}");
                                Console.WriteLine($"Conteudo: {body}");
                            }
                        }catch { }                 
                    }
                }
            }

            Console.ReadKey();
        }

        private static void SendWithNameButNotInMessage() {
            var apiKey = "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";
            var api = new SendGridApi(apiKey);

            var archive1 = $"{Environment.CurrentDirectory}\\Emils\\e-mail_08_11_18.txt";

            var msg1 = "";

            using (var sr = new StreamReader(archive1, Encoding.GetEncoding("iso-8859-1"))) {
                string contato;
                var contatos = new List<Contact>();

                while ((contato = sr.ReadLine()) != null) {
                    contato = contato.Trim();

                    if (!string.IsNullOrEmpty(contato)) {
                        var nameC = contato.Split(';');

                        if (nameC[1].Trim().IsValidEmail()) {
                            contatos.Add(new Contact { Name = nameC[0].Trim(), Email = nameC[1].Trim() });
                        }
                    }
                }

                var emailsSpliteed = contatos.SplitList(300);

                var i = 1;

                foreach (var splited in emailsSpliteed) {
                    var email = new Email {
                        From = new Contact { Name = "", Email = "" },
                        To = splited,
                        Subject = "",
                        PlainTextContent = "",
                        HtmlContent = msg1
                    };


                    var response = api.SendToMultipleRecipients(email).Result;
                    var statusOde = response.StatusCode;
                    var header = response.Headers;
                    var body = response.Body.ReadAsStringAsync().Result;

                    Console.WriteLine($"Gropo {i}:");
                    Console.WriteLine($"Status code: {statusOde}");
                    Console.WriteLine($"Conteudo: {body}");

                    i++;
                }
            }

            Console.ReadKey();
        }
    }
}
