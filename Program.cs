using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Envie uma mensagem");
            string msg = Console.ReadLine();

            Console.WriteLine("Enviando mensagem.");

            var sendMensage = EnvioSMS(msg);

            if(MessageResource.StatusEnum.Delivered.ToString().Contains("delivered"))
            Console.Write("Mensagem enviada!");

            else
                Console.Write("Erro no envio!");
        }

        static MessageResource EnvioSMS(string message)
        {
            var accountSid = "AC71283a50de2c831bc8492651d52509c2";
            var authToken = "52f62a56e5846b2a274a6dec507a8c08";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+5511942588196"));
            messageOptions.MessagingServiceSid = "MG4ee2d99df1574173104256da6e074d7b";
            messageOptions.Body = message;

            //var msg = MessageResource.Create(messageOptions);
            //Console.WriteLine(msg.Body);
            return MessageResource.Create(messageOptions);
        }
    }
}
