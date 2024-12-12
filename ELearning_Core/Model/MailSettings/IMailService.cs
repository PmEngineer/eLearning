using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.MailSettings
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
