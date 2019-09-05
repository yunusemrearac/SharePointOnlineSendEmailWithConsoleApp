using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePointOnlineSendEmailWithConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientContext clientContext = new ClientContext(ConfigurationManager.AppSettings["siteUrl"].ToString());

            clientContext.AuthenticationMode = ClientAuthenticationMode.Default;

            string password = ConfigurationManager.AppSettings["userPassword"].ToString();
            System.Security.SecureString passwordChar = new System.Security.SecureString();
            foreach (char ch in password)
                passwordChar.AppendChar(ch);

            clientContext.Credentials = new SharePointOnlineCredentials(ConfigurationManager.AppSettings["userEmail"].ToString(), passwordChar);

            var emailp = new EmailProperties();
            emailp.To = new List<string> { "yunusemrearac@yunusemrearac.onmicrosoft.com" };
            emailp.Body = "Yunus Emre Araç test email";
            emailp.Subject = "Yunus Emre Araç sitesi için deneme mail gönderimidir.";

            Utility.SendEmail(clientContext, emailp);
            clientContext.ExecuteQuery();

        }
    }
}
