using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDomain.Entities
{
    public class EmailSettings
    {
        public string MailToAddress = "fluffytoycoy@gmail.com";
        public string MailFromAddress = "fluffytoycoy@gmail.com";
        public bool UseSsl = true;
        public string Username = "SmtpUsername";
        public string Password = "SmtpPassword";
        public string SeverName = "smtp.email.com";
        public int SeverPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"D:\www";
    }
}
