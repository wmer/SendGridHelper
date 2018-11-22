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
            SendWithoutName();
        }
        
        private static void SendWithoutName() {
            var apiKey = "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";
            var api = new SendGridApi(apiKey);

            var archive1 = $"{Environment.CurrentDirectory}\\Emils\\E-MAIL PROSPECÇÃO_22_11.txt";

            var txt = File.ReadAllText(archive1, Encoding.GetEncoding("iso-8859-1"));
            txt = txt.Replace(",", Environment.NewLine);
            txt = txt.Replace(";", Environment.NewLine);

            File.WriteAllText(archive1, txt);

            var msg1 = $"Chegou no seu bairro a Internet Fibra Óptica, venha se conectar com ultravelocidade.<br/><br/>Para os primeiros 200 clientes, desconto nos primeiros 3 meses no plano Turbo Fibra 20 MB de R$ 129,00 por R$89,90, Taxa de instalação facilitada em até 3X, ou Turbo Fibra 50 MB de R$ 169,00 por R$ 119,90,  taxa de instalação GRÁTIS.<br/><br/>Ligue agora <a href=\"tel: 40202324\">40202324</a> ou WhatsApp <a href=\"https://api.whatsapp.com/send?phone=5564993331062\">64993331062</a>";

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
                        From = new Contact { Name = "Lanteca Telecom", Email = "relacionamento@lantecatelecom.com.br" },
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

            var archive1 = $"{Environment.CurrentDirectory}\\Emils\\E-MAIL CLIENTES DE 3 A 60 DIAS_19_11.txt";

            var msg1 = "{0}<br/><br/>Somos da TelBe, notamos que houve algum imprevisto com o pagamento da fatura.<br/><br/>Estamos aqui para lhe ajudar.Não perca tempo!<br/><br/>Providencie o pagamento do boleto retirando no portal do assinante: http://www.portaltelbe.com.br ou entre em contato conosco no telefone abaixo, para maiores informações.<br/><br/>                Ligue agora: <a href='tel: 1145943346'>11 4594-3346</a>(Itatiba)<br/>                      <a href='tel: 1935157200'>19 3515 - 7200</a>(Demais Regiões)<br/><br/>Caso tenha pago, favor desconsiderar esse e-mail.<br/>Att,<br/>";

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
                                    From = new Contact { Name = "TelBe", Email = "cobranca@telbe.com.br" },
                                    To = contacts,
                                    Subject = "Comunicado TelBe",
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
