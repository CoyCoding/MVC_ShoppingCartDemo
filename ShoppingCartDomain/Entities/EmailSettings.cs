using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDomain.Entities
{
    public class EmailSettings
    {
        public string MailToAddress { get; set; }
        public string MailFromAddress { get; set; }
        public bool UseSsl = false;
        public string Username { get; set; }
        public string Password { get; set; }
        public string SeverName { get; set; }
        public int SeverPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"D:\";
    }
}
