using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Email
{
    public interface IEmailSender
    {
        void Send(EmailDto dto);
    }

    public class EmailDto
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string To { get; set; }
    }
}
